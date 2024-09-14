﻿using EvoSC.Common.Interfaces.Models;
using EvoSC.Common.Util;
using EvoSC.Common.Util.ServerUtils;
using EvoSC.Common.Util.TextFormatting;

namespace EvoSC.Common.Remote;

public partial class ServerClient
{
    private TextFormatter MakeInfoMessage(string text) =>
        new TextFormatter()
            .AddText(GameIcons.Icons.ExclamationCircle, styling => styling.WithColor(new TextColor(_themes.Theme.Chat_Info)))
            .AddText(" ")
            .AddText(text);

    private TextFormatter MakeSuccessMessage(string text) =>
        new TextFormatter()
            .AddText(GameIcons.Icons.CheckCircle, styling => styling.WithColor(new TextColor(_themes.Theme.Chat_Success)))
            .AddText(" ")
            .AddText(text);
    
    private TextFormatter MakeWarningMessage(string text) =>
        new TextFormatter()
            .AddText(GameIcons.Icons.ExclamationTriangle, styling => styling.WithColor(new TextColor(_themes.Theme.Chat_Warning)))
            .AddText(" ")
            .AddText(text);
    
    private TextFormatter MakeErrorMessage(string text) =>
        new TextFormatter()
            .AddText("", styling => styling.WithColor(new TextColor(_themes.Theme.Chat_Danger)))
            .AddText(" ")
            .AddText(text);

    public Task InfoMessageAsync(string text) =>
        Chat.SendChatMessageAsync(MakeInfoMessage(text));

    public Task InfoMessageAsync(IPlayer player, string text) =>
        Chat.SendChatMessageAsync(MakeInfoMessage(text), player);
    
    public Task SuccessMessageAsync(string text) =>
        Chat.SendChatMessageAsync(MakeSuccessMessage(text));

    public Task SuccessMessageAsync(IPlayer player, string text) =>
        Chat.SendChatMessageAsync(MakeSuccessMessage(text), player);
    
    public Task WarningMessageAsync(string text) =>
        Chat.SendChatMessageAsync(MakeWarningMessage(text));

    public Task WarningMessageAsync(IPlayer player, string text) =>
        Chat.SendChatMessageAsync(MakeWarningMessage(text), player);
    
    public Task ErrorMessageAsync(string text) =>
        Chat.SendChatMessageAsync(MakeErrorMessage(text));

    public Task ErrorMessageAsync(IPlayer player, string text) =>
        Chat.SendChatMessageAsync(MakeErrorMessage(text), player);
}
