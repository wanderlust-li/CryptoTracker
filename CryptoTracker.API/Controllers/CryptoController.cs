using CryptoTracker.Application.Features.SupportedCryptos;
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

}