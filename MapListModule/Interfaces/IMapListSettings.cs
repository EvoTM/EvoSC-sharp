using Config.Net;
using EvoSC.Modules.Attributes;

namespace EvoSC.Modules.Official.MapListModule.Interfaces;

[Settings]
public interface IMapListSettings
{
    [Option(DefaultValue = 1)]
    public int CurrentMapIndex { get; set; }
}
