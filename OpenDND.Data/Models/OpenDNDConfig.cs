namespace OpenDND.Data.Models
{
    public class OpenDNDConfig
    {
        public string DbConnection { get; set; }
        public string SentryIOToken { get; set; }
        public string DiscordToken { get; set; }
        
        public string DiscordClientId { get; set; }

        public string DiscordClientSecret { get; set; }

        public string LogWebhookToken { get; set; }

        public ulong LogWebhookId { get; set; }

        public int MessageCacheSize { get; set; } = 10;
        public string WebsiteBaseUrl { get; set; } = "https://ainz.app";
        
        public string GoogleOAuthID { get; set; }
        public string GoogleOAuthSecret { get; set; }
    }
}