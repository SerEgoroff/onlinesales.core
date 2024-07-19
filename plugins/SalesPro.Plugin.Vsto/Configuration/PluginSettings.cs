namespace SalesPro.Plugin.Vsto.Configuration;

public class PluginConfig
{
    public VstoConfig Vsto { get; set; } = new VstoConfig();
}

public class VstoConfig
{
    public string RequestPath { get; set; } = string.Empty;

    public string LocalPath { get; set; } = string.Empty;

    public string SubPathPrefix { get; set; } = string.Empty;
}