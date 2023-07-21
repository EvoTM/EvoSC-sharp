using EvoSC.Common.Controllers;
using EvoSC.Common.Controllers.Attributes;
using EvoSC.Common.Events.Attributes;
using EvoSC.Common.Interfaces.Controllers;
using EvoSC.Common.Remote;
using EvoSC.Modules.Official.MapListModule.Interfaces;
using GbxRemoteNet.Events;
using GbxRemoteNet.Interfaces;

namespace EvoSC.Modules.Official.MapListModule.Controllers;

[Controller]
public class MapListEventController : EvoScController<IEventControllerContext>
{
    private readonly IMapListService _mapListService;
    private readonly IGbxRemoteClient _gbx;

    public MapListEventController(IMapListService mapListService, IGbxRemoteClient gbx)
    {
        _mapListService = mapListService;
        _gbx = gbx;
    }

    [Subscribe(GbxRemoteEvent.EndMatch)]
    public void OnMatchEnded(object sender, EndMatchGbxEventArgs args)
    {
        var index = _mapListService.GetNextMap()?.Index ?? -1;
        if (index == -1)
            return;
        _gbx.SetNextMapIndexAsync(index);
    }
}
