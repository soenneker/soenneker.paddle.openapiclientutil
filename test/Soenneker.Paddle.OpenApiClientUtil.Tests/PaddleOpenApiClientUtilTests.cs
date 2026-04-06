using Soenneker.Paddle.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Paddle.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class PaddleOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IPaddleOpenApiClientUtil _openapiclientutil;

    public PaddleOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IPaddleOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
