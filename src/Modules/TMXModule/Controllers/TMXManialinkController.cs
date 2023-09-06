using EvoSC.Common.Controllers.Attributes;
using EvoSC.Manialinks;
using EvoSC.Modules.Official.TmxModule.Interfaces;

namespace EvoSC.Modules.Official.TmxModule.Controllers;

[Controller]
public class TmxManialinkController: ManialinkController
{
    private readonly IAddMapService _addMapService;

    public TmxManialinkController(IAddMapService addMapService)
    {
        _addMapService = addMapService;
    }

    public async Task AddMapAsync(string id)
    {
        await _addMapService.AddTmxMapAsync(id, Context.Player);
    }

    public async Task AddMapPackAsync(string id)
    {
        await _addMapService.AddTmxMapPackAsync(id, Context.Player);
    }
}
