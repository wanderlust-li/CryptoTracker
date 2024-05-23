using Newtonsoft.Json;

namespace CryptoTracker.Domain;

public class Asset
{
    [JsonProperty("asset_id")]
    public string AssetId { get; set; }
    
    [JsonProperty("url")]
    public string IconUrl { get; set; }
}

