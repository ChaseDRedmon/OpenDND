using Newtonsoft.Json;

namespace OpenDND.Data.Models.DND
{
    public enum MoralAlignment
    {
        Good,
        Neutral,
        Evil
    }

    public enum EthicalAlignment
    {
        Lawful,
        Neutral,
        Chaotic
    }
    
    public class Character
    {
        [JsonProperty("PlayerName")]
        public string PlayerName { get; set; }
        
        // Todo: Create 1-1 relationship here
        public ClassRootObject Class { get; set; }
        
        // Todo: Create 1-1 relationship here
        public BackgroundRootObject Background { get; set; }
        
        // Todo: Create 1-1 relationship here
        public RacesRootObject Race { get; set; }
        
        public MoralAlignment Moral { get; set; }
        
        public EthicalAlignment Ethics { get; set; }
        
        public int Level { get; set; }
    }
}