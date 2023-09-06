using System.Data;
using CaseExtensions;
using EvoSC.Common.Exceptions;
using EvoSC.Common.Interfaces.Localization;
using EvoSC.Common.Interfaces.Models;
using EvoSC.Common.Interfaces.Services;
using EvoSC.Common.Models.Maps;
using EvoSC.Common.Remote;
using EvoSC.Common.Services;
using EvoSC.Common.Services.Attributes;
using EvoSC.Modules.Official.TmxModule.Events;
using EvoSC.Modules.Official.TmxModule.Interfaces;
using EvoSC.Modules.Official.TmxModule.Models;

namespace EvoSC.Modules.Official.TmxModule.Services;

[Service]
public class AddMapService : IAddMapService
{
    private readonly IMxMapService _mxMapService;
    private readonly IMapService _mapService;
    private readonly dynamic _locale;
    private readonly ServerClient _server;
    private readonly AuditService _auditService;

    public AddMapService(IMxMapService mxMapService, Locale locale, IMapService mapService, ServerClient server, AuditService auditService)
    {
        _mxMapService = mxMapService;
        _locale = locale;
        _mapService = mapService;
        _server = server;
        _auditService = auditService;
    }

    public async Task AddTmxMapAsync(string id, IPlayer player)
    {
        MapStream? mapStream;
        try
        {
            mapStream = await _mxMapService.FindAndDownloadMapAsync(Convert.ToInt32(id), null);
        }
        catch (Exception)
        {
            await _server.ErrorMessageAsync(_locale.PlayerLanguage.FailedAddingMap(id), player);
            throw;
        }

        if (mapStream == null)
        {
            await _server.ErrorMessageAsync(_locale.PlayerLanguage.MapIdNotFound(id), player);
            return;
        }

        IMap? map;
        try
        {
            map = await _mapService.AddMapAsync(mapStream);
        }
        catch (DuplicateMapException e)
        {
            await _server.ErrorMessageAsync(_locale.PlayerLanguage.DuplicateMap(id), player);
            throw;
        }
        
        _auditService.NewEvent(AuditEvents.MapAdded).Success().HavingProperties(new { Map = mapStream })
            .Comment(_locale.Audit_MapAdded);

        await _server.SuccessMessageAsync(_locale.PlayerLanguage.MapAddedSuccessfully(map.Name, map.Author?.NickName), player);
    }
    
    public async Task AddTmxMapPackAsync(string id, IPlayer player)
    {
        MapPackStream? mapPackStream;
        try
        {
            mapPackStream = await _mxMapService.FindAndDownloadMapPackAsync(Convert.ToInt32(id), null);
        }
        catch (DuplicateNameException)
        {
            await _server.ErrorMessageAsync(_locale.PlayerLanguage.DuplicateMap(id), player);
            return;
        }
        catch (Exception)
        {
            await _server.ErrorMessageAsync(_locale.PlayerLanguage.FailedAddingMap(id), player);
            throw;
        }

        if (mapPackStream == null)
        {
            await _server.ErrorMessageAsync(_locale.PlayerLanguage.MapIdNotFound(id), player);
            return;
        }

        var maps = await _mapService.AddMapsAsync(mapPackStream.Maps, $"tmx-{mapPackStream.Metadata.ID}-{mapPackStream.Metadata.Name.ToKebabCase()}");

        _auditService.NewEvent(AuditEvents.MapPackAdded).Success()
            .HavingProperties(new { Maps = maps, MapPack = mapPackStream.Metadata })
            .Comment(_locale.Audit_MapAdded);

        await _server.SuccessMessageAsync(_locale.PlayerLanguage.MapPackAddedSuccessfully(mapPackStream.Metadata.Name, mapPackStream.Metadata.Username, mapPackStream.Metadata.TrackCount),
            player);
    }
}
