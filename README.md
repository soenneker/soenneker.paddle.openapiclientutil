[![](https://img.shields.io/nuget/v/soenneker.paddle.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.paddle.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.paddle.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.paddle.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.paddle.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.paddle.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.paddle.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.paddle.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Paddle.OpenApiClientUtil

Provides a configured Paddle billing API client and reuses it for the lifetime of the registered service.

## Installation

```bash
dotnet add package Soenneker.Paddle.OpenApiClientUtil
```

## Configuration

```json
{
  "Paddle": {
    "ApiKey": "your-server-side-api-key"
  }
}
```

Set `Paddle:ClientBaseUrl` to `https://sandbox-api.paddle.com` when using a sandbox API key. The default is Paddle's live API.

## Usage

```csharp
using Soenneker.Paddle.OpenApiClientUtil.Abstract;
using Soenneker.Paddle.OpenApiClientUtil.Registrars;

services.AddPaddleOpenApiClientUtilAsSingleton();

IPaddleOpenApiClientUtil paddle = serviceProvider
    .GetRequiredService<IPaddleOpenApiClientUtil>();

var client = await paddle.Get(cancellationToken);
var eventTypes = await client.EventTypes.GetAsync(cancellationToken: cancellationToken);
```

Use `AddPaddleOpenApiClientUtilAsScoped()` when each application scope should have its own generated client wrapper. The underlying authenticated HTTP provider remains shared and is disposed by the service container at shutdown.
