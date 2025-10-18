using Newtonsoft.Json;

namespace TrashTracker.Core.DTO.Waste;

public class WasteScheduleResponseDTO
{
    [JsonProperty("nazwa")]
    public string? Name { get; set; }

    [JsonProperty("rok")]
    public string? Year { get; set; }

    [JsonProperty("miesiac_od")]
    public int? MonthFrom { get; set; }

    [JsonProperty("miesiac_do")]
    public int? MonthTo { get; set; }

    [JsonProperty("frakcje")]
    public Dictionary<string, string>? Fractions { get; set; }

    [JsonProperty("odbior")]
    public List<WasteCleaningItemDTO>? Collections { get; set; }

    [JsonProperty("numer_posesji")]
    public string? PropertyNumber { get; set; }

    [JsonProperty("typ_nieruchomosci")]
    public string? PropertyType { get; set; }

    [JsonProperty("miejscowosc")]
    public string? Locality { get; set; }

    [JsonProperty("ulica")]
    public string? Street { get; set; }

    [JsonProperty("numer_domu")]
    public string? HouseNumber { get; set; }

    [JsonProperty("dzielnica")]
    public string? District { get; set; }
}