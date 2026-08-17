using Soenneker.Tests.HostedUnit;

namespace Soenneker.Segment.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class SegmentOpenApiClientTests : HostedUnitTest
{
    public SegmentOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
