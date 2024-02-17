using Newtonsoft.Json;

namespace OrgX.Projects.Api.WebApi.PostModels
{
    public class PostResponse<TResults>(
        PostMetadata? metadata,
        TResults? results)
    {
        [JsonProperty("metadata", Order = 0)]
        public PostMetadata? Metadata => metadata;
        [JsonProperty("results", Order = 1)]
        public TResults? Results => results;
    }
}
