using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace OrgX.Projects.Api.WebApi.PostModels;

[ExcludeFromCodeCoverage]
public class PostResponse<TResults>(
    PostMetadata? metadata,
    TResults? results)
{
    [JsonProperty("metadata", Order = 0)]
    public PostMetadata? Metadata => metadata;
    [JsonProperty("results", Order = 1)]
    public TResults? Results => results;
}
