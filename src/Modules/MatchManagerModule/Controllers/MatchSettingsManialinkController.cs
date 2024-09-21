using EvoSC.Common.Controllers.Attributes;
using EvoSC.Manialinks;
using EvoSC.Manialinks.Attributes;
using EvoSC.Modules.Official.MatchManagerModule.Interfaces;

namespace EvoSC.Modules.Official.MatchManagerModule.Controllers;

[Controller]
public class MatchSettingsManialinkController(IMatchManagerHandlerService matchManagerHandlerService) : ManialinkController
{
    [ManialinkRoute(Route = "load/{name}")]
    public Task LoadAsync(string name) => matchManagerHandlerService.LoadMatchSettingsAsync(name, Context.Player);
}
