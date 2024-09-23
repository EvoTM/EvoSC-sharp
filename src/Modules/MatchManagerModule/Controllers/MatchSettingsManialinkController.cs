using EvoSC.Common.Controllers.Attributes;
using EvoSC.Manialinks;
using EvoSC.Manialinks.Attributes;
using EvoSC.Modules.Official.MatchManagerModule.Interfaces;

namespace EvoSC.Modules.Official.MatchManagerModule.Controllers;

[Controller]
public class MatchSettingsManialinkController(
    IMatchManagerHandlerService matchManagerHandlerService,
    IMatchSettingsManagerService matchSettingsManagerService) : ManialinkController
{
    [ManialinkRoute(Route = "load/{name}")]
    public Task LoadAsync(string name) => matchManagerHandlerService.LoadMatchSettingsAsync(name, Context.Player);

    [ManialinkRoute(Route = "edit/{name}")]
    public Task EditAsync(string name) => matchSettingsManagerService.ShowEditMatchSettingsUiAsync(Context.Player, name);
}
