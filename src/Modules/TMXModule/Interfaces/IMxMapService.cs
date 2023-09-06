using System.IO;
using System.Threading.Tasks;
using EvoSC.Common.Interfaces.Models;
using EvoSC.Common.Models.Maps;
using EvoSC.Modules.Official.TmxModule.Models;
using ManiaExchange.ApiClient.Api.Models;
using ManiaExchange.ApiClient.Models;

namespace EvoSC.Modules.Official.TmxModule.Interfaces;

public interface IMxMapService
{
    /// <summary>
    /// Downloads a map from TrackmaniaExchange if it exists with the given ID.
    /// </summary>
    /// <param name="mxId">The maps MXID</param>
    /// <param name="shortName">If the map is hidden, the short name have to be given for it to find the map.</param>
    /// <returns></returns>
    Task<MapStream?> FindAndDownloadMapAsync(int mxId, string? shortName);

    Task<TmxMapInfo?> FindMap(int mxId, string? shortName);
    Task<Stream?> DownloadMap(int mxId, string? shortName);

    Task<MapPackStream?> FindAndDownloadMapPackAsync(int mxId, string? shortName);

    Task<TmxMappackInfo?> FindMapPack(int mxId, string? shortName);

    Task<TmxMappackMapInfo[]> FindMapPackMaps(int mxId, string? shortName);
}
