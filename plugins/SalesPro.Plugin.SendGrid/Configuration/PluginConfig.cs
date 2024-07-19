using SalesPro.Configuration;

namespace SalesPro.Plugin.SendGrid.Configuration;

public class PluginConfig
{
    public SendGridApiConfig SendGridApi { get; set; } = new SendGridApiConfig();
}

public class SendGridApiConfig
{
    public string PrimaryApiKey { get; set; } = string.Empty;

    public List<string> SecondaryApiKeys { get; set; } = new List<string>();

    public List<string> WebhookPublicKeys { get; set; } = new List<string>();
}