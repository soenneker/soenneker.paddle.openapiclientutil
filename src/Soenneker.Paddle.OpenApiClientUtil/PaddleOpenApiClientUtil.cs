using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Paddle.HttpClients.Abstract;
using Soenneker.Paddle.OpenApiClientUtil.Abstract;
using Soenneker.Paddle.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Paddle.OpenApiClientUtil;

///<inheritdoc cref="IPaddleOpenApiClientUtil"/>
public sealed class PaddleOpenApiClientUtil : IPaddleOpenApiClientUtil
{
    private readonly AsyncSingleton<PaddleOpenApiClient> _client;

    public PaddleOpenApiClientUtil(IPaddleOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<PaddleOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Paddle:ApiKey");
            string authHeaderValueTemplate = configuration["Paddle:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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
