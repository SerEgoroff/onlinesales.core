using System.ComponentModel;

namespace SalesPro.Geography;

public enum Continent
{
    [Description("Unknown")]
    ZZ = 0,

    [Description("Africa")]
    AF = 1,
    [Description("Antarctica")]
    AN = 2,
    [Description("Asia")]
    AS = 3,
    [Description("Europe")]
    EU = 4,
    [Description("North America")]
    NA = 5,
    [Description("Oceania")]
    OC = 6,
    [Description("South America")]
    SA = 7,
}