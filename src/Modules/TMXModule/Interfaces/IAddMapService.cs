using EvoSC.Common.Interfaces.Models;

namespace EvoSC.Modules.Official.TmxModule.Interfaces;

public interface IAddMapService
{
    Task AddTmxMapAsync(string id, IPlayer player);
    Task AddTmxMapPackAsync(string id, IPlayer player);
}
