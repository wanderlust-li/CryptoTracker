using CryptoTracker.Application.Exceptions;
using CryptoTracker.Domain;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;

namespace CryptoTracker.Application.Features.SupportedCryptos;

public class GetSupportedCryptosHandler : IRequestHandler<GetSupportedCryptosQuery, List<Asset>>
{
    private readonly IRestClient _client;
    private readonly string _apiKey;
    
    public GetSupportedCryptosHandler(IConfiguration configuration, IRestClient client)
    {
        _client = client;
        _apiKey = configuration["CryptoAPI_ApiKey"];
    }
    
    public async Task<List<Asset>> Handle(GetSupportedCryptosQuery request, CancellationToken cancellationToken)
    {
        var restRequest = new RestRequest("v1/assets", Method.Get);
        restRequest.AddHeader("Accept", "application/json");
        restRequest.AddHeader("X-CoinAPI-Key", _apiKey);

        var response = await _client.ExecuteAsync(restRequest, cancellationToken);
        
        if (!response.IsSuccessful)
        {
            throw new BadRequestException($"API request failed: {response.StatusCode}, Content: {response.Content}");
        }
        
        var cryptos = JsonConvert.DeserializeObject<List<Asset>>(response.Content);
        return cryptos;
    }
}
