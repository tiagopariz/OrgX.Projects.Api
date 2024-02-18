using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace OrgX.Projects.Api.WebApi.GetModels;

[ExcludeFromCodeCoverage]
public class GetResponse<TResults>(
    GetMetadata? metadata,
    TResults? results)
{
    [JsonProperty("metadata", Order = 0)]
    public GetMetadata? Metadata { get; } = metadata;
    [JsonProperty("results", Order = 1)]
    public TResults? Results { get; } = results;
}
