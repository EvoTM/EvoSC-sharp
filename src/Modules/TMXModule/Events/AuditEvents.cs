using EvoSC.Common.Util.EnumIdentifier;

namespace EvoSC.Modules.Official.TmxModule.Events;

public enum AuditEvents
{
    [Identifier(Name = "TMX:MapAdded")]
    MapAdded,
    [Identifier(Name = "TMX:MapPackAdded")]
    MapPackAdded
}
