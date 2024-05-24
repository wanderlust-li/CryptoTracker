using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CryptoTracker.Domain;

public class GetCryptoByIdResponse
{
    [JsonProperty("time")]
    public DateTime Time { get; set; }

    [JsonProperty("asset_id_base")]
    public string AssetIdBase { get; set; }

    [JsonProperty("asset_id_quote")]
    public string AssetIdQuote { get; set; }

    [JsonProperty("rate")]
    public double Rate { get; set; }
    
}