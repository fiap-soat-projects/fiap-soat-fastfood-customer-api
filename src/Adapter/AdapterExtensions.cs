using Adapter.Controllers;
using Adapter.Controllers.Interfaces;
using Adapter.Gateways;
using Domain.Gateways.Repositories.Interfaces;
using Domain.UseCases;
using Domain.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Adapter;

[ExcludeFromCodeCoverage]
public static class AdapterExtensions
{
    public static IServiceCollection AddAdapters(this IServiceCollection services)
    {
        services
            .AddGateways()
            .AddUseCases()
            .AddControllers();

        return services;
    }

    internal static IServiceCollection AddGateways(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerGateway>();

        return services;
    }

    internal static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<ICustomerUseCase, CustomerUseCase>();

        return services;
    }

    internal static IServiceCollection AddControllers(this IServiceCollection services)
    {
        services.AddScoped<ICustomerController, CustomerController>();

        return services;
    }
}
