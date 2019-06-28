using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenDND.Data.Models.Core
{
    public class SpeedMonsters
    {
        [JsonProperty("walk")]
        public int? WalkingDistance { get; set; }
        
        [JsonProperty("swim")]
        public int? SwimmingDistance { get; set; }
        
        [JsonProperty("fly")]
        public int? FlyingDistance { get; set; }
        
        [JsonProperty("burrow")]
        public int? BurrowingDistance { get; set; }
        
        [JsonProperty("climb")]
        public int? ClimbingDistance { get; set; }
        
        [JsonProperty("hover")]
        public bool? CanHover { get; set; }
    }

    public class ActionMonsters
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("desc")]
        public string Description { get; set; }
        
        [JsonProperty("attack_bonus")]
        public int? AttackBonus { get; set; }
        
        [JsonProperty("damage_dice")]
        public string DamageDice { get; set; }
        
        [JsonProperty("damage_bonus")]
        public int? DamageBonus { get; set; }
    }

    public class ResultMonsters
    {
        [JsonProperty("slug")]
        public string Slug { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("size")]
        public string Size { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("subtype")]
        public string Subtype { get; set; }
        
        [JsonProperty("group")]
        public string Group { get; set; }
        
        [JsonProperty("alignment")]
        public string Alignment { get; set; }
        
        [JsonProperty("armor_class")]
        public int ArmorClass { get; set; }
        
        [JsonProperty("armor_desc")]
        public string ArmorDescription { get; set; }
        
        [JsonProperty("hit_points")]
        public int HitPoints { get; set; }
        
        [JsonProperty("hit_dice")]
        public string HitDice { get; set; }
        
        [JsonProperty("SpeedMonsters")]
        public SpeedMonsters Speed { get; set; }
        
        [JsonProperty("strength")]
        public int Strength { get; set; }
        
        [JsonProperty("dexterity")]
        public int Dexterity { get; set; }
        
        [JsonProperty("constitution")]
        public int Constitution { get; set; }
        
        [JsonProperty("intelligence")]
        public int Intelligence { get; set; }
        
        [JsonProperty("wisdom")]
        public int Wisdom { get; set; }
        
        [JsonProperty("charisma")]
        public int Charisma { get; set; }
        
        [JsonProperty("strength_save")]
        public int? StrengthSave { get; set; }
        
        [JsonProperty("dexterity_save")]
        public int? DexteritySave { get; set; }
        
        [JsonProperty("constitution_save")]
        public int? ConstitutionSave { get; set; }
        
        [JsonProperty("intelligence_save")]
        public int? IntelligenceSave { get; set; }
        
        [JsonProperty("wisdom_save")]
        public int? WisdomSave { get; set; }
        
        [JsonProperty("charisma_save")]
        public int? CharismaSave { get; set; }
        
        [JsonProperty("perception")]
        public int? Perception { get; set; }
        
        [JsonProperty("damage_vulnerabilities")]
        public string DamageVulnerabilities { get; set; }
        
        [JsonProperty("damage_resistances")]
        public string DamageResistances { get; set; }
        
        [JsonProperty("damage_immunities")]
        public string DamageImmunities { get; set; }
        
        [JsonProperty("condition_immunities")]
        public string ConditionImmunities { get; set; }
        
        [JsonProperty("senses")]
        public string Senses { get; set; }
        
        [JsonProperty("languages")]
        public string Languages { get; set; }
        
        [JsonProperty("challenge_rating")]
        public string ChallengeRating { get; set; }
        
        [JsonProperty("ActionMonsters")]
        public List<ActionMonsters> Actions { get; set; }
        
        [JsonProperty("reactions")]
        public object Reactions { get; set; }
        
        [JsonProperty("legendary_actions")]
        public object LegendaryActions { get; set; }
        
        [JsonProperty("special_abilities")]
        public object SpecialAbilities { get; set; }
        
        [JsonProperty("document_slug")]
        public string DocumentSlug { get; set; }
    }

    public class RootMonsters
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("next")]
        public string NextPage { get; set; }
        
        [JsonProperty("previous")]
        public string PreviousPage { get; set; }
        
        [JsonProperty("results")]
        public List<ResultMonsters> Results { get; set; }
    }
}