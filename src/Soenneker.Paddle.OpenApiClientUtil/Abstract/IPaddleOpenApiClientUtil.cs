using Soenneker.Paddle.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Paddle.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached Paddle billing API client backed by the configured HTTP provider.
/// </summary>
public interface IPaddleOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached Paddle client, creating it on the first call.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured Paddle client.</returns>
    ValueTask<PaddleOpenApiClient> Get(CancellationToken cancellationToken = default);
}
