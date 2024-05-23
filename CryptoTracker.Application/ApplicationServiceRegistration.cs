using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;

namespace CryptoTracker.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this  IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        
        services.AddSingleton<IRestClient, RestClient>(provider =>
        {
            var options = new RestClientOptions("https://rest.coinapi.io/")
            {
                
            };
            return new RestClient(options);
        });

        return services;
    }
}