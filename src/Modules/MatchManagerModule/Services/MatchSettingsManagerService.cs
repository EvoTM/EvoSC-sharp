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

    public async Task ShowEditMatchSettingsUiAsync(IPlayer player, string name)
    {
        var matchSettings = await matchSettingsService.GetMatchSettingsAsync(name);

        var trans = manialinks.CreateTransaction();
        await trans.SendManialinkAsync(player, "MatchManagerModule.EditMatchSettings", new { matchSettings });
        await trans.HideManialinkAsync(player, "MatchManagerModule.MatchSettingsManager");
        await trans.CommitAsync();
    }
}
