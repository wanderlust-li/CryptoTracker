using CryptoTracker.Application.Exceptions;
using CryptoTracker.Domain;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace CryptoTracker.Application.Features.Cryptos;

public class GetCryptoByIdHandler : IRequestHandler<GetCryptoByIdQuery, GetCryptoByIdResponse>
{
    private readonly IRestClient _client;
    private readonly string _apiKey;
    
    public GetCryptoByIdHandler(IConfiguration configuration, IRestClient client)
    {
        _client = client;
        _apiKey = configuration["CryptoAPI_ApiKey"];
    }

    public async Task<GetCryptoByIdResponse> Handle(GetCryptoByIdQuery request, CancellationToken cancellationToken)
    {
        var restRequest = new RestRequest($"v1/exchangerate/{request.AssetId}/{request.Currency}", Method.Get);
        restRequest.AddHeader("Accept", "application/json");
        restRequest.AddHeader("X-CoinAPI-Key", _apiKey);
        
        var response = await _client.ExecuteAsync(restRequest, cancellationToken);
        
        if (!response.IsSuccessful)
        {
            throw new BadRequestException($"API request failed: {response.StatusCode}, Content: {response.Content}");
        }
        
        var cryptosById = JsonConvert.DeserializeObject<GetCryptoByIdResponse>(response.Content);

        return cryptosById;
    }
}