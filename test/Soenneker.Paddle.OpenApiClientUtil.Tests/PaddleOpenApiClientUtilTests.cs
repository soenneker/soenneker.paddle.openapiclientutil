using Soenneker.Paddle.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Paddle.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class PaddleOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IPaddleOpenApiClientUtil _openapiclientutil;

    public PaddleOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IPaddleOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
