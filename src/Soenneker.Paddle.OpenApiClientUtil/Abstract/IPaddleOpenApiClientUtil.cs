using Soenneker.Paddle.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Paddle.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IPaddleOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<PaddleOpenApiClient> Get(CancellationToken cancellationToken = default);
}
