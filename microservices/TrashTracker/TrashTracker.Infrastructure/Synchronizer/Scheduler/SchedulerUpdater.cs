using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TrashTracker.Core.Configuration;
using TrashTracker.Core.Date;
using TrashTracker.Core.DTO.Waste;
using TrashTracker.Core.Repositories;

namespace TrashTracker.Infrastructure.Synchronizer.Scheduler;

internal partial class SchedulerUpdater(
    ILogger<SchedulerUpdater> logger,
    IHttpClientFactory httpClientFactory,
    ILocalityRepository localityRepository,
    IWasteTypeRepository wasteTypeRepository,
    ICollectionDateRepository collectionDateRepository,
    IOptions<TrashTrackerConfiguration> configuration
) : ISchedulerUpdater
{

    public async Task UpdateSchedulesAsync()
    {
        var cfg = configuration.Value;

        if (string.IsNullOrWhiteSpace(cfg.KomaApiPath))
        {
            logger.LogWarning("⚠️ Missing KomaApiPath in configuration.");
            return;
        }

        try
        {
            logger.LogInformation("📥 Fetching data from KOMA API...");
            var http = httpClientFactory.CreateClient();
            var json = await http.GetStringAsync(cfg.KomaApiPath);

            if (string.IsNullOrWhiteSpace(json))
            {
                logger.LogWarning("⚠️ Empty response from KOMA API.");
                return;
            }

            var apiData = JsonConvert.DeserializeObject<WasteScheduleResponseDTO>(json);
            if (apiData?.Locality is not { Length: > 0 } locality)
            {
                logger.LogWarning("⚠️ Invalid data returned from KOMA API.");
                return;
            }

            logger.LogInformation("🏘 Processing locality: {Loc}", locality);

            var mpoEntries = ParseMpoEntries(cfg.MpoSchedules);
            var mergedEntries = MergeSchedules(apiData, mpoEntries);

            var localityEntity = await localityRepository.EnsureExists(locality.ToUpperInvariant());

            foreach (var (wasteType, date) in mergedEntries)
            {
                var typeEntity = await wasteTypeRepository.EnsureExists(wasteType);
                await collectionDateRepository.EnsureExists(localityEntity.Id, typeEntity.Id, date);
            }

            logger.LogInformation("✅ Saved {Count} schedule entries for {Loc}", mergedEntries.Count, locality);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "❌ Error while updating waste collection schedule.");
        }
    }

    private static List<ScheduleEntry> ParseMpoEntries(MpoSchedulesConfiguration mpo)
    {
        return new[]
        {
            ("Tworzywa sztuczne i metale + papier", mpo.PlasticAndPaperDates),
            ("Szkło", mpo.GlassDates)
        }
        .Where(x => !string.IsNullOrWhiteSpace(x.Item2))
        .SelectMany(x => ExtractDates(x.Item2!)
            .Select(date => new ScheduleEntry(x.Item1, date)))
        .ToList();
    }

    private static IEnumerable<DateTime> ExtractDates(string text)
    {
        foreach (Match m in MyRegex().Matches(text))
        {
            if (!int.TryParse(m.Groups[1].Value, out var day) ||
                !RomanHelper.RomanMonths.TryGetValue(m.Groups[2].Value.ToUpperInvariant(), out var month)) continue;
            if (DateTime.TryParse($"2025-{month:D2}-{day:D2}", out var date))
                yield return date;
        }
    }

    private static List<ScheduleEntry> MergeSchedules(WasteScheduleResponseDTO apiData, List<ScheduleEntry> mpoEntries)
    {
        var all = new List<ScheduleEntry>();

        if (apiData.Collections != null)
        {
            all.AddRange(apiData.Collections
                .Where(c => c.Date is not null && !string.IsNullOrWhiteSpace(c.Type))
                .Select(c => new ScheduleEntry(c.Type!.Trim(), c.Date!.Value)));
        }

        all.AddRange(mpoEntries);

        return all
            .DistinctBy(e => (e.WasteType.ToUpperInvariant(), e.Date))
            .OrderBy(e => e.Date)
            .ToList();
    }

    private sealed record ScheduleEntry(string WasteType, DateTime Date);

    [GeneratedRegex(@"(\d{1,2})\.(I{1,3}|IV|V|VI|VII|VIII|IX|X|XI|XII)", RegexOptions.IgnoreCase, "pl-PL")]
    private static partial Regex MyRegex();
}
