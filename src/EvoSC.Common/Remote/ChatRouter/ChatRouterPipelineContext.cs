﻿using EvoSC.Common.Interfaces.Middleware;
using EvoSC.Common.Interfaces.Models;

namespace EvoSC.Common.Remote.ChatRouter;

public class ChatRouterPipelineContext : IPipelineContext
{
    public required bool ForwardMessage { get; set; }
    public required IPlayer Author { get; init; }
    public required string MessageText { get; set; }
    public required List<IPlayer> Players { get; set; }
}
