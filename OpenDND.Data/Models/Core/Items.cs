using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenDND.Data.Models.Core
{
    public class ResultItems
    {
        [JsonProperty("slug")]
        public string Slug { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("desc")]
        public string Desc { get; set; }
        
        [JsonProperty("rarity")]
        public string Rarity { get; set; }
        
        [JsonProperty("requires_attunement")]
        public string RequiresAttunement { get; set; }
        
        [JsonProperty("document_slug")]
        public string DocumentSlug { get; set; }
    }

    public class RootItems
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("next")]
        public string Next { get; set; }
        
        [JsonProperty("previous")]
        public string Previous { get; set; }
        
        [JsonProperty("results")]
        public List<ResultItems> Results { get; set; }
    }
}