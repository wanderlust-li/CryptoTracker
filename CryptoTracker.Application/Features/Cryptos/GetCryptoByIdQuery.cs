using CryptoTracker.Domain;
using MediatR;

namespace CryptoTracker.Application.Features.Cryptos;

public class GetCryptoByIdQuery : IRequest<GetCryptoByIdResponse>
{
    public string AssetId { get; set; }
    public string Currency { get; set; }

    public GetCryptoByIdQuery(string assetId, string currency)
    {
        AssetId = assetId;
        Currency = currency;
    }
}