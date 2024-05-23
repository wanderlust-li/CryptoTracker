using Newtonsoft.Json;

namespace CryptoTracker.Domain;

public class Asset
{
    [JsonProperty("metric_id")]
    public string AssetId { get; set; }
}

