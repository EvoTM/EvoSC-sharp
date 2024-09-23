using EvoSC.Common.Interfaces.Models;

namespace EvoSC.Modules.Official.MatchManagerModule.Interfaces;

public interface IMatchSettingsManagerService
{
    public Task ShowManagerUiAsync(IPlayer player);
    public Task ShowEditMatchSettingsUiAsync(IPlayer player, string name);
}
