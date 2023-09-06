using EvoSC.Common.Models.Maps;
using ManiaExchange.ApiClient.Api.Models;

namespace EvoSC.Modules.Official.TmxModule.Models;

public record MapPackStream(TmxMappackInfo Metadata, List<MapStream> Maps);
