using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenDND.Data.Models.DND
{
    public class BackgroundResult
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("desc")]
        public string Desc { get; set; }
        
        [JsonProperty("slug")]
        public string Slug { get; set; }
        
        [JsonProperty("skill_proficiencies")]
        public string SkillProficiencies { get; set; }
        
        [JsonProperty("tool_proficiencies")]
        public string ToolProficiencies { get; set; }
        
        [JsonProperty("languages")]
        public string Languages { get; set; }
        
        [JsonProperty("equipment")]
        public string Equipment { get; set; }
        
        [JsonProperty("feature")]
        public string Feature { get; set; }
        
        [JsonProperty("feature_desc")]
        public string FeatureDesc { get; set; }
        
        [JsonProperty("suggested_characteristics")]
        public string SuggestedCharacteristics { get; set; }
        
        [JsonProperty("document__slug")]
        public string DocumentSlug { get; set; }
        
        [JsonProperty("document__title")]
        public string DocumentTitle { get; set; }
        
        [JsonProperty("document__license_url")]
        public string DocumentLicenseUrl { get; set; }
    }

    public class BackgroundRootObject
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("next")]
        public object Next { get; set; }
        
        [JsonProperty("previous")]
        public object Previous { get; set; }
        
        [JsonProperty("results")]
        public List<BackgroundResult> Results { get; set; }
    }
}