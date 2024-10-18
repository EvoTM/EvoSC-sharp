using EvoSC.Common.Controllers.Attributes;
using EvoSC.Manialinks;
using EvoSC.Manialinks.Attributes;

namespace EvoSC.Modules.Official.MatchManagerModule.Controllers;

[Controller]
public class EditMatchSettingsManialinkController : ManialinkController
{
    [ManialinkRoute(Route = "edit/{name}")]
    public Task EditAsync(string name)
    {
        return Task.CompletedTask;
    }
}
