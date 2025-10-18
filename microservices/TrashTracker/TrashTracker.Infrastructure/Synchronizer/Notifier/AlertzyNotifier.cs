using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TrashTracker.Core.Configuration;
using TrashTracker.Core.Repositories;

namespace TrashTracker.Infrastructure.Synchronizer.Notifier;

internal class AlertzyNotifier(
    ILogger<AlertzyNotifier> logger,
    IHttpClientFactory httpClientFactory,
    ILocalityRepository localityRepository,
    IWasteTypeRepository wasteTypeRepository,
    ICollectionDateRepository collectionDateRepository,
    IOptions<AlertzyConfiguration> configuration
) : IAlertzyNotifier
{
    private readonly string _alertzyUrl = "https://alertzy.app/send";

    public async Task CheckUpcomingCollectionsAndNotifyAsync()
    {
        try
        {
            var today = DateTime.Today;
            var notificationOffsets = new[] { 2, 1 }; // 2 dni przed, 1 dzień przed

            logger.LogInformation("🔍 Checking upcoming waste collections for notifications...");

            var collections = await collectionDateRepository.GetAllAsync();

            foreach (var offset in notificationOffsets)
            {
                var targetDate = today.AddDays(offset);
                var upcoming = collections
                    .Where(c => c.Date.Date == targetDate)
                    .ToList();

                if (!upcoming.Any())
                {
                    logger.LogInformation("ℹ️ No collections found for {Date}", targetDate);
                    continue;
                }

                foreach (var collection in upcoming)
                {
                    var locality = await localityRepository.GetByIdAsync(collection.LocalityId);
                    var wasteType = await wasteTypeRepository.GetByIdAsync(collection.WasteTypeId);

                    string when = offset switch
                    {
                        1 => "jutro",
                        2 => "za 2 dni",
                        _ => $"za {offset} dni"
                    };

                    string message =
                        $"📅 Przypomnienie!\n" +
                        $"Odbiór: **{wasteType.Name}** {when}.\n" +
                        $"Miejscowość: {locality.Name}\n" +
                        $"Data: {collection.Date:dd.MM.yyyy}";

                    await SendAlertzyNotificationAsync("Odbiór śmieci", message);
                }

                logger.LogInformation("✅ Sent {Count} notifications for collections {DaysBefore} days before ({Date})",
                    upcoming.Count, offset, targetDate);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "❌ Error while sending Alertzy notifications.");
        }
    }

    private async Task SendAlertzyNotificationAsync(string title, string message)
    {
        var apiKey = configuration.Value.ApiKey;
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException("❌ Alertzy API key missing in configuration.");
        }

        var http = httpClientFactory.CreateClient();
        var payload = new Dictionary<string, string>
        {
            { "accountKey", apiKey },
            { "title", title },
            { "message", message }
        };

        var response = await http.PostAsync(_alertzyUrl, new FormUrlEncodedContent(payload));
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            logger.LogWarning("⚠️ Alertzy returned {Status}: {Body}", response.StatusCode, body);
        }
    }
}
