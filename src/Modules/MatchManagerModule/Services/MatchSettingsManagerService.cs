using EvoSC.Common.Interfaces.Models;
using EvoSC.Common.Interfaces.Services;
using EvoSC.Common.Services.Attributes;
using EvoSC.Manialinks.Interfaces;
using EvoSC.Modules.Official.MatchManagerModule.Interfaces;

namespace EvoSC.Modules.Official.MatchManagerModule.Services;

[Service]
public class MatchSettingsManagerService(IMatchSettingsService matchSettingsService, IManialinkManager manialinks) : IMatchSettingsManagerService
{
    public async Task ShowManagerUiAsync(IPlayer player)
    {
        var matchSettings = await matchSettingsService.GetAvailableMatchSettings();
        await manialinks.SendManialinkAsync(player, "MatchManagerModule.MatchSettingsManager",
            new { availableMatchSettings = matchSettings });
    }
}
