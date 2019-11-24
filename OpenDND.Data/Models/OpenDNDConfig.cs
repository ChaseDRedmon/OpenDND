namespace OpenDND.Data.Models
{
    public class OpenDNDConfig
    {
        public string DbConnection { get; set; }
        public string SentryIOToken { get; set; }
        public string DiscordToken { get; set; }

        public string StackoverflowToken { get; set; }

        public string LogWebhookToken { get; set; }

        public ulong LogWebhookId { get; set; }

        public string DiscordClientId { get; set; }

        public string DiscordClientSecret { get; set; }

        public int MessageCacheSize { get; set; } = 10;

        public string ReplUrl { get; set; }

        public string IlUrl { get; set; }
        public string WebsiteBaseUrl { get; set; } = "https://mod.gg";

        public bool EnableStatsd { get; set; }
    }
}