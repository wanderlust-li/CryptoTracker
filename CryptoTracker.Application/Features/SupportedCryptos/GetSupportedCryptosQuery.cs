using CryptoTracker.Domain;
using MediatR;

namespace CryptoTracker.Application.Features.SupportedCryptos;

public class GetSupportedCryptosQuery : IRequest<List<Asset>>
{
}