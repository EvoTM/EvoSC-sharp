﻿using EvoSC.Common.Controllers.Attributes;
using EvoSC.Manialinks;
using EvoSC.Modules.Official.Scoreboard.Interfaces;

namespace EvoSC.Modules.Official.Scoreboard.Controllers;

[Controller]
public class ScoreboardManialinkController : ManialinkController
{
    private readonly IScoreboardService _scoreboardService;

    public ScoreboardManialinkController(IScoreboardService scoreboardService) =>
        _scoreboardService = scoreboardService;

    public Task ResendScoreboardAsync() => _scoreboardService.ShowScoreboardAsync(Context.Player);
}
