using Newtonsoft.Json;

namespace CryptoTracker.Domain;

public class Asset
{
    [JsonProperty("asset_id")]
    public string AssetId { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
}

