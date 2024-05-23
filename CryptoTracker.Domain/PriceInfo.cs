namespace CryptoTracker.Domain;

public class PriceInfo
{
    public string AssetId { get; set; } 
    public decimal Price { get; set; } 
    public DateTime TimeUpdated { get; set; } 
}