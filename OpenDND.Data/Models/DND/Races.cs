using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenDND.Data.Models.DND
{
    public class Asi
    {
        [JsonProperty("attributes")]
        public List<string> Attributes { get; set; }
        
        [JsonProperty("value")]
        public int Value { get; set; }
    }

    public class Speed
    {
        [JsonProperty("walk")]
        public int Walk { get; set; }
    }

    public class RacesResult
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("slug")]
        public string Slug { get; set; }
        
        [JsonProperty("desc")]
        public string Description { get; set; }
        
        [JsonProperty("asi_desc")]
        public string AsiDesc { get; set; }
        
        [JsonProperty("asi")]
        public List<Asi> Asi { get; set; }
        
        [JsonProperty("age")]
        public string Age { get; set; }
        
        [JsonProperty("alignment")]
        public string Alignment { get; set; }
        
        [JsonProperty("size")]
        public string Size { get; set; }
        
        [JsonProperty("speed")]
        public Speed Speed { get; set; }
        
        [JsonProperty("speed_desc")]
        public string SpeedDesc { get; set; }
        
        [JsonProperty("languages")]
        public string Languages { get; set; }
        
        [JsonProperty("vision")]
        public string Vision { get; set; }
        
        [JsonProperty("traits")]
        public string Traits { get; set; }
        
        [JsonProperty("subraces")]
        public List<object> Subraces { get; set; }
        
        [JsonProperty("document__slug")]
        public string DocumentSlug { get; set; }
        
        [JsonProperty("document__title")]
        public string DocumentTitle { get; set; }
        
        [JsonProperty("document__license_url")]
        public string DocumentLicenseUrl { get; set; }
    }

    public class RacesRootObject
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("next")]
        public object Next { get; set; }
        
        [JsonProperty("previous")]
        public object Previous { get; set; }
        
        [JsonProperty("results")]
        public List<RacesResult> Results { get; set; }
    }
}