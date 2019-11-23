using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenDND.Data.Models.DND
{
    public class ResultSpells
    {
        [JsonProperty("slug")]
        public string Slug { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("desc")]
        public string Description { get; set; }
        
        [JsonProperty("higher_level")]
        public string HigherLevel { get; set; }
        
        [JsonProperty("page")]
        public string Page { get; set; }
        
        [JsonProperty("range")]
        public string Range { get; set; }
        
        [JsonProperty("components")]
        public string Components { get; set; }
        
        [JsonProperty("material")]
        public string Materials { get; set; }
        
        [JsonProperty("ritual")]
        public string Ritual { get; set; }
        
        [JsonProperty("duration")]
        public string Duration { get; set; }
        
        [JsonProperty("concentration")]
        public string Concentration { get; set; }
        
        [JsonProperty("casting_time")]
        public string CastingTime { get; set; }
        
        [JsonProperty("level")]
        public string Level { get; set; }
        
        [JsonProperty("school")]
        public string School { get; set; }
        
        [JsonProperty("dnd_class")]
        public string DndClass { get; set; }
        
        [JsonProperty("archetype")]
        public string Archetype { get; set; }
        
        [JsonProperty("circles")]
        public string Circles { get; set; }
        
        [JsonProperty("document_slug")]
        public string DocumentSlug { get; set; }
    }

    public class RootSpells
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("next")]
        public string NextPage { get; set; }
        
        [JsonProperty("previous")]
        public string PreviousPage { get; set; }
        
        [JsonProperty("results")]
        public List<ResultSpells> Results { get; set; }
    }
}