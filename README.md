[![](https://img.shields.io/nuget/v/soenneker.segment.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.segment.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.segment.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.segment.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.segment.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.segment.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.segment.openapiclient/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.segment.openapiclient/actions/workflows/codeql.yml)

# Soenneker.Segment.OpenApiClient

A Kiota-generated .NET client for Segment's Public API.

## Installation

```bash
dotnet add package Soenneker.Segment.OpenApiClient
```

For dependency injection, cached transport, and token configuration, install the companion utility:

```bash
dotnet add package Soenneker.Segment.OpenApiClientUtil
```

## Usage with the client utility

```json
{
  "Segment": {
    "ApiToken": "your-segment-token"
  }
}
```

```csharp
using Soenneker.Segment.OpenApiClient;
using Soenneker.Segment.OpenApiClient.Models;
using Soenneker.Segment.OpenApiClientUtil.Abstract;
using Soenneker.Segment.OpenApiClientUtil.Registrars;

services.AddSegmentOpenApiClientUtilAsSingleton();

public sealed class SegmentWarehouseReader(ISegmentOpenApiClientUtil clientUtil)
{
    public async Task<ListWarehouses200SegmentV1JsonResponse?> GetWarehouses(
        CancellationToken cancellationToken)
    {
        SegmentOpenApiClient client = await clientUtil.Get(cancellationToken);
        return await client.Warehouses.GetAsync(cancellationToken: cancellationToken);
    }
}
```

The root client exposes request builders such as `Sources`, `Destinations`, `Warehouses`, `TrackingPlans`, `Users`, and `AuditEvents`. Item endpoints use indexers with the resource identifier, for example `client.Warehouses[warehouseId]`.

Kiota maps documented error responses to generated exception models such as `RequestErrorEnvelope`; catch the specific generated error type when an application needs to inspect API error details.

The client itself requires a Kiota `IRequestAdapter`. The companion utility supplies the adapter, cached HTTP transport, base URL, and authentication header. Generated request builders and models can change when Segment's specification changes, so map them into application-owned contracts at your service boundary when API stability matters.
