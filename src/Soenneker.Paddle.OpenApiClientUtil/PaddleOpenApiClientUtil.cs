using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Paddle.HttpClients.Abstract;
using Soenneker.Paddle.OpenApiClient;
using Soenneker.Paddle.OpenApiClientUtil.Abstract;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Paddle.OpenApiClientUtil;

public sealed class PaddleOpenApiClientUtil : IPaddleOpenApiClientUtil
{
    private readonly AsyncSingleton<PaddleOpenApiClient> _client;

    public PaddleOpenApiClientUtil(IPaddleOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<PaddleOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            if (httpClient.BaseAddress is not null)
                requestAdapter.BaseUrl = httpClient.BaseAddress.ToString().TrimEnd('/');

            return new PaddleOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<PaddleOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
