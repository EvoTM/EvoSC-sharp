﻿namespace EvoSC.Modules.Official.Scoreboard.Interfaces;

public interface IScoreboardService
{
    public Task ShowScoreboard(string playerLogin);
    public Task HideNadeoScoreboard();
    public Task ShowNadeoScoreboard();
}
