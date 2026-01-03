using Infrastructure.Exceptions;
using Infrastructure.Sql.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureExtensions
{
    const string POSTGRES_CONNECTION_STRING_VARIABLE_KEY = "PostgresConnectionString";

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSqlContext();

        return services;
    }

    internal static IServiceCollection AddSqlContext(this IServiceCollection services)
    {
        var postgresConnectionString = Environment.GetEnvironmentVariable(POSTGRES_CONNECTION_STRING_VARIABLE_KEY);

        EnvironmentVariableNotFoundException.ThrowIfIsNullOrWhiteSpace(postgresConnectionString, POSTGRES_CONNECTION_STRING_VARIABLE_KEY);

        services.AddDbContext<CustomerSqlContext>(options =>
        {
            options.UseNpgsql(postgresConnectionString);
        });

        return services;
    }
}
