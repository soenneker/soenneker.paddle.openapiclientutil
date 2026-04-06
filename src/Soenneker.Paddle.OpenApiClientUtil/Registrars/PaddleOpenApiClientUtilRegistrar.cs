using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Paddle.HttpClients.Registrars;
using Soenneker.Paddle.OpenApiClientUtil.Abstract;

namespace Soenneker.Paddle.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class PaddleOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="PaddleOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddPaddleOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddPaddleOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IPaddleOpenApiClientUtil, PaddleOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="PaddleOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddPaddleOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddPaddleOpenApiHttpClientAsSingleton()
                .TryAddScoped<IPaddleOpenApiClientUtil, PaddleOpenApiClientUtil>();

        return services;
    }
}
