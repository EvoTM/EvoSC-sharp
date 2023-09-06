using System.Data;
using EvoSC.Commands.Attributes;
using EvoSC.Commands.Interfaces;
using EvoSC.Common.Controllers;
using EvoSC.Common.Controllers.Attributes;
using EvoSC.Common.Exceptions;
using EvoSC.Common.Interfaces;
using EvoSC.Common.Interfaces.Localization;
using EvoSC.Common.Interfaces.Models;
using EvoSC.Common.Interfaces.Services;
using EvoSC.Common.Models.Maps;
using EvoSC.Manialinks.Interfaces;
using EvoSC.Modules.Official.TmxModule.Events;
using EvoSC.Modules.Official.TmxModule.Interfaces;
using EvoSC.Modules.Official.TmxModule.Models;
using EvoSC.Modules.Official.TmxModule.Permissions;
using Microsoft.Extensions.Logging;

namespace EvoSC.Modules.Official.TmxModule.Controllers;

[Controller]
public class TmxCommandController : EvoScController<ICommandInteractionContext>
{
    private readonly IMxMapService _mxMapService;
    private readonly IManialinkManager _manialinkManager;
    private readonly IAddMapService _addMapService;

    public TmxCommandController(ILogger<TmxCommandController> logger, IMxMapService mxMapService, IMapService mapService,
        IServerClient server, Locale locale, IManialinkManager manialinkManager, IAddMapService addMapService)
    {
        _mxMapService = mxMapService;
        _manialinkManager = manialinkManager;
        _addMapService = addMapService;
    }
    
    [ChatCommand("tmxMapAdd", "[Commmand.Add]", MapsPermissions.AddMap)]
    public async Task AddMapAsync(string mapId)
    {
        await _addMapService.AddTmxMapAsync(mapId, Context.Player);
    }

    [ChatCommand("tmxMapInfo", "[Commmand.Add]")]
    public async Task InfoMapAsync(string mapId)
    {
        var info = await _mxMapService.FindMap(Convert.ToInt32(mapId), null);
        if (info != null)
        {
            await _manialinkManager.SendManialinkAsync(Context.Player, "TmxModule.MapInfo", new { info });
        }
    }
    
    [ChatCommand("tmxMapPackAdd", "[Commmand.Add]", MapsPermissions.AddMap)]
    public async Task AddMapPackAsync(string mapId)
    {
        await _addMapService.AddTmxMapPackAsync(mapId, Context.Player);
    }
    
    [ChatCommand("tmxMapPackInfo", "[Commmand.Add]")]
    public async Task InfoMapPackAsync(string mapId)
    {
        var packInfo = await _mxMapService.FindMapPack(Convert.ToInt32(mapId), null);
        var mapsInfo = await _mxMapService.FindMapPackMaps(Convert.ToInt32(mapId), null);
        if (packInfo != null)
        {
            await _manialinkManager.SendManialinkAsync(Context.Player, "TmxModule.MapPackInfo", new { info = packInfo, maps = mapsInfo });
        }
    }
}
