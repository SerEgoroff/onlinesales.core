using System.ComponentModel.DataAnnotations.Schema;

namespace SalesPro.Plugin.Vsto.Entities;

[Table("vsto_user_version")]
public class VstoUserVersion
{
    public int Id { get; set; }

    public string IpAddress { get; set; } = string.Empty;

    public string Version { get; set; } = string.Empty;

    public DateTime ExpireDateTime { get; set; }

    public string Subfolder { get; set; } = string.Empty;
}