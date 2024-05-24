using System.ComponentModel.DataAnnotations;
using CryptoTracker.Application.Features.Cryptos;
using CryptoTracker.Application.Features.SupportedCryptos;
using CryptoTracker.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CryptoTracker.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CryptoController : ControllerBase
{
    private readonly IMediator _mediator;

    public CryptoController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("supported-cryptocurrencies")]
    public async Task<IActionResult> GetSupportedCryptocurrencies()
    {
        var query = new GetSupportedCryptosQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    
    /// <summary>
    /// Retrieves pricing information for a specific cryptocurrency.
    /// Used to request the price of a cryptocurrency in a fiat currency.
    /// </summary>
    /// <param name="assetId">The ID of the cryptocurrency, e.g., 'BTC'</param>
    /// <param name="currency">The fiat currency, e.g., 'USD'</param>
    /// <returns>Information about the cryptocurrency price and the time of the last update</returns>
    /// <response code="200">Returns the price and update time of the cryptocurrency</response>
    /// <response code="400">If invalid parameters are provided</response>
    [HttpGet("get-crypto-price")]
    [ProducesResponseType(typeof(GetCryptoByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCryptoPrice([Required] string assetId, [Required] string currency)
    {
        var query = new GetCryptoByIdQuery(assetId, currency);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}