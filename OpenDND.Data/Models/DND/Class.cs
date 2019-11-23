using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenDND.Data.Models.DND
{
    public class Archetype
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("slug")]
        public string Slug { get; set; }
        
        [JsonProperty("desc")]
        public string Desc { get; set; }
        
        [JsonProperty("document__slug")]
        public string DocumentSlug { get; set; }
        
        [JsonProperty("document__title")]
        public string DocumentTitle { get; set; }
        
        [JsonProperty("document__license_url")]
        public string DocumentLicenseUrl { get; set; }
    }

    public class ClassResult
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("slug")]
        public string Slug { get; set; }
        
        [JsonProperty("desc")]
        public string Desc { get; set; }
        
        [JsonProperty("hit_dice")]
        public string HitDice { get; set; }
        
        [JsonProperty("hp_at_1st_level")]
        public string HpAt1StLevel { get; set; }
        
        [JsonProperty("hp_at_higher_levels")]
        public string HpAtHigherLevels { get; set; }
        
        [JsonProperty("prof_armor")]
        public string ProficientArmor { get; set; }
        
        [JsonProperty("prof_weapons")]
        public string ProficientWeapons { get; set; }
        
        [JsonProperty("prof_tools")]
        public string ProficientTools { get; set; }
        
        [JsonProperty("prof_saving_throws")]
        public string ProficientSavingThrows { get; set; }
        
        [JsonProperty("prof_skills")]
        public string ProficientSkills { get; set; }
        
        [JsonProperty("equipment")]
        public string Equipment { get; set; }
        
        [JsonProperty("table")]
        public string Table { get; set; }
        
        [JsonProperty("spellcasting_ability")]
        public string SpellcastingAbility { get; set; }
        
        [JsonProperty("subtypes_name")]
        public string SubtypesName { get; set; }
        
        [JsonProperty("archetypes")]
        public List<Archetype> Archetypes { get; set; }
        
        [JsonProperty("document__slug")]
        public string DocumentSlug { get; set; }
        
        [JsonProperty("document__title")]
        public string DocumentTitle { get; set; }
        
        [JsonProperty("document__license_url")]
        public string DocumentLicenseUrl { get; set; }
    }

    public class ClassRootObject
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("next")]
        public object Next { get; set; }
        
        [JsonProperty("previous")]
        public object Previous { get; set; }
        
        [JsonProperty("results")]
        public List<ClassResult> Results { get; set; }
    }
}