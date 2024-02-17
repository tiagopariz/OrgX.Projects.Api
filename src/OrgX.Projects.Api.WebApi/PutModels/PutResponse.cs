using Newtonsoft.Json;

namespace OrgX.Projects.Api.WebApi.PutModels
{
    public class PutResponse<TResults>(
        PutMetadata? metadata,
        TResults? results)
    {
        [JsonProperty("metadata", Order = 0)]
        public PutMetadata? Metadata { get; } = metadata;
        [JsonProperty("results", Order = 1)]
        public TResults? Results { get; } = results;
    }
}
