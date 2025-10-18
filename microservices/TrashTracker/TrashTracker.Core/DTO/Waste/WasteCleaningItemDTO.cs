using Newtonsoft.Json;

namespace TrashTracker.Core.DTO.Waste;

public class WasteCleaningItemDTO
{
    [JsonProperty("data")]
    public DateTime? Date { get; set; }

    [JsonProperty("typ")]
    public string? Type { get; set; }
}