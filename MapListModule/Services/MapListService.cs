using EvoSC.Common.Interfaces.Database.Repository;
using EvoSC.Modules.Official.MapListModule.Classes;
using EvoSC.Modules.Official.MapListModule.Interfaces;
using ManiaExchange.ApiClient;
using ManiaExchange.ApiClient.Models;
using Microsoft.Extensions.Logging;

namespace EvoSC.Modules.Official.MapListModule.Services;

public class MapListService : IMapListService
{
    private readonly IMapListSettings _settings;
    private readonly IMapRepository _mapRepository;
    private readonly MxTmApi _tmxApi = new("EvoSC#");
    private readonly ILogger<MapListService> _logger;
    
    public MapListService(IMapListSettings settings, IMapRepository mapRepository, 
        ILogger<MapListService> logger)
    {
        _settings = settings;
        _mapRepository = mapRepository;
        _logger = logger;
    }
    
    public List<QueuedMap> MapQueue { get; set; } = new();

    public async Task<TmxMapInfo?> GetMapInfo(QueuedMap? map)
    {
        if (map is null)
        {
            return null;
        }

        var mapDbInfo = await _mapRepository.GetMapByIdAsync(map.Index);
        if (mapDbInfo is null)
        {
            _logger.LogDebug("Couldn't find any map in Database with id {id}", map.Index);
            return null;
        }
        var mapInfo = await _tmxApi.GetMapInfoAsync(mapDbInfo.Uid);
        if (mapInfo is null)
        {
            _logger.LogDebug("Could not find any map info for ID {id} from Trackmania Exchange", mapDbInfo.Uid);
        }
        
        return mapInfo;
    }

    public void GetMapInfo(int index) => GetMapInfo(MapQueue.FirstOrDefault(r => r.Index == index));
    
    public QueuedMap? GetNextMap()
    {
        MapQueue.Sort();
        var map = MapQueue.FirstOrDefault(r => r.Index == _settings.CurrentMapIndex);
        return map ?? MapQueue.FirstOrDefault();
    }

    public void AddMap(int mapIndex)
    {
        if (MapQueue.FirstOrDefault(r => r.Index == mapIndex) is QueuedMap map)
        {
            // As the map already exists, we just move it to the back of the list.
            MapQueue.Remove(map);
            AddMap(map.Index);
        }
        else
        {
            MapQueue = MapQueue.Append(new QueuedMap(mapIndex, MapQueue.Count + 1)).ToList();
            RecalculateOrder();
            MapQueue.Sort();
        }
    }
    
    public void RemoveMapFromQueue(int mapIndex)
    {
        if (MapQueue.FirstOrDefault(r => r.Index == mapIndex) is QueuedMap map)
        {
            MapQueue.Remove(map);
        }
        RecalculateOrder();
    }
    
    public void PrependMap(int mapIndex)
    {
        if (MapQueue.FirstOrDefault(r => r.Index == mapIndex) is QueuedMap map)
        {
            // As the map already exists, we just move it to the front of the list.
            MapQueue.Remove(map);
            PrependMap(map.Index);
        }
        else
        {
            MapQueue = MapQueue.Prepend(new QueuedMap(mapIndex, 0)).ToList();
            RecalculateOrder();
            MapQueue.Sort(); // Sorts the list based on the order.
        }
    }

    public void InsertMap(int index, int mapIndex)
    {
        MapQueue.Insert(index, new QueuedMap(mapIndex, index));
        RecalculateOrder();
    }
    
    private void RecalculateOrder()
    {
        MapQueue.Sort();
        for (int i = 0; i < MapQueue.Count; i++)
        {
            MapQueue[i].Order = i;
        }
    }
}
