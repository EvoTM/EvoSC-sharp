using EvoSC.Commands.Interfaces;
using EvoSC.Common.Controllers;
using EvoSC.Common.Controllers.Attributes;
using GbxRemoteNet.Interfaces;

namespace EvoSC.Modules.Official.MapListModule.Controllers;

[Controller]
public class MapListCommandController : EvoScController<ICommandInteractionContext>
{
    private readonly IGbxRemoteClient _gbx;

    public MapListCommandController(IGbxRemoteClient gbx)
    {
        _gbx = gbx;
    }
}
