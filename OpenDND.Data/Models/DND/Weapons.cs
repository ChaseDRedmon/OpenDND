using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenDND.Data.Models.DND
{
    public class WeaponsResult
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("slug")]
        public string Slug { get; set; }
        
        [JsonProperty("category")]
        public string Category { get; set; }
        
        [JsonProperty("document__slug")]
        public string DocumentSlug { get; set; }
        
        [JsonProperty("document__title")]
        public string DocumentTitle { get; set; }
        
        [JsonProperty("document__license_url")]
        public string DocumentLicenseUrl { get; set; }
        
        [JsonProperty("cost")]
        public string Cost { get; set; }
        
        [JsonProperty("damage_dice")]
        public string DamageDice { get; set; }
        
        [JsonProperty("damage_type")]
        public string DamageType { get; set; }
        
        [JsonProperty("weight")]
        public string Weight { get; set; }
        
        [JsonProperty("properties")]
        public List<object> Properties { get; set; }
    }

    public class WeaponsRootObject
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("next")]
        public object Next { get; set; }
        
        [JsonProperty("previous")]
        public object Previous { get; set; }
        
        [JsonProperty("results")]
        public List<WeaponsResult> Results { get; set; }
    }
}