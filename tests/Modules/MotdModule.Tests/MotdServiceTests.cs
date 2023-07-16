﻿using EvoSC.Commands.Interfaces;
using EvoSC.Common.Interfaces.Controllers;
using EvoSC.Common.Interfaces.Models;
using EvoSC.Common.Interfaces.Services;
using EvoSC.Manialinks.Interfaces;
using EvoSC.Modules.Official.MotdModule.Database.Models;
using EvoSC.Modules.Official.MotdModule.Interfaces;
using EvoSC.Modules.Official.MotdModule.Services;
using EvoSC.Testing;
using EvoSC.Testing.Controllers;
using Microsoft.Extensions.Logging;
using Moq;

namespace MotdModule.Tests;

public class MotdServiceTests
{
    private readonly Mock<IManialinkManager> _maniaLinkManager = new();
    private readonly Mock<IHttpService> _httpService = new();
    private readonly Mock<IMotdRepository> _repository = new();
    private readonly Mock<IMotdSettings> _settings = new();
    private readonly Mock<ILogger<MotdService>> _logger = new();
    private readonly Mock<IOnlinePlayer> _player = new();
    private readonly Mock<IPlayerManagerService> _playerManager = new();
    private readonly Mock<IContextService> _context;
    
    private readonly ControllerContextMock<ICommandInteractionContext> _commandContext = Mocking.NewControllerContextMock<ICommandInteractionContext>();

    
    
    private MotdService? _motdService;

    public MotdServiceTests()
    {
        _context = Mocking.NewContextServiceMock(_commandContext.Context.Object, null);
    }

    private void SetupMocks(int interval = 200)
    {
        _httpService.Setup(r => r.GetAsync(It.IsAny<string>()))
            .Returns(Task.FromResult("test"));
        _settings.Setup(r => r.MotdFetchInterval)
            .Returns(interval);
    }

    private void SetupController()
    {
        _motdService = new(_maniaLinkManager.Object, _httpService.Object, _repository.Object, _settings.Object,
            _logger.Object, _context.Object, _playerManager.Object);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    [InlineData(false, true)]
    private async Task SetMotdSource_Test(bool local, bool presetUseLocal = false)
    {
        SetupMocks(200);
        if (presetUseLocal)
        {
            _settings.Setup(r => r.UseLocalMotd).Returns(true);
        }
        SetupController();
        await Task.Delay(1000);
        if (!presetUseLocal)
        {
            _settings.Setup(r => r.UseLocalMotd).Returns(true);
        }
        _httpService.Setup(r => r.GetAsync(It.IsAny<string>()))
            .Returns(Task.FromResult("test"));
        _motdService.SetMotdSource(local, _player.Object);
        _httpService.Invocations.Clear();
        await Task.Delay(300);
        _httpService.Verify(r => r.GetAsync(It.IsAny<string>()), (local) ? Times.Never : Times.Once);
    }

    [Fact]
    private async Task SetLocalMotd_Test()
    {
        SetupMocks();
        SetupController();
        var a = new { text = "test" };
        _maniaLinkManager.Setup(r =>
            r.SendManialinkAsync(_player.Object, "MotdModule.MotdEdit", a))
            .Returns(Task.CompletedTask);
        
        _settings.Setup(r => r.MotdLocalText).Returns("test");
        
        _motdService.SetLocalMotd("test", _player.Object);
        
        await _motdService.ShowEditAsync(_player.Object);
        _maniaLinkManager.Verify(r =>
            r.SendManialinkAsync(_player.Object, "MotdModule.MotdEdit", It.IsAny<object>()), Times.Once);

        var motdText = await _motdService.GetMotdAsync();
        Assert.Equal(a.text, motdText);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(6)]
    private async Task SetInterval_Test(int times)
    {
        SetupMocks();
        SetupController();
        _motdService!.SetInterval(100, _player.Object);
        await Task.Delay(110 * times);
        _httpService.Verify(r => r.GetAsync(It.IsAny<string>()),
            Times.Exactly(times));
    }

    [Fact]
    private async Task SetUrl_Test()
    {
        SetupMocks();
        SetupController();
        _httpService.Setup(r => r.GetAsync("test")).Returns(Task.FromResult("test"));
        _motdService!.SetInterval(1000, _player.Object);
        _motdService.SetUrl("test", _player.Object);
        await Task.Delay(1000);

        _httpService.Verify(r => r.GetAsync("test"), Times.Exactly(2));
    }

    [Fact]
    private async Task GetEntry_Test()
    {
        SetupMocks();
        SetupController();
        _repository.Setup(r => r.GetEntryAsync(_player.Object))
            .Returns(Task.FromResult(new MotdEntry())!);
        await _motdService!.GetEntryAsync(_player.Object);
        
        _repository.Verify(r => r.GetEntryAsync(_player.Object), Times.Once);
    }
    
    [Fact]
    private async Task InsertOrUpdateEntry_Test()
    {
        SetupMocks();
        SetupController();
        _repository.Setup(r => r.InsertOrUpdateEntryAsync(_player.Object, true))
            .Returns(Task.FromResult(new MotdEntry()));
        await _motdService!.InsertOrUpdateEntryAsync(_player.Object, true);
        
        _repository.Verify(r => r.InsertOrUpdateEntryAsync(_player.Object, true), Times.Once);
    }

    [Fact]
    private async Task SetUrlReEnable_Test()
    {
        SetupMocks();
        SetupController();
        _httpService.Setup(r => r.GetAsync(It.IsAny<string>()))
            .Throws(new InvalidOperationException());
        
        await Task.Delay(1000);
        _httpService.Verify(r => r.GetAsync(It.IsAny<string>()), Times.AtLeast(1));
        _motdService!.SetUrl("test", _player.Object);
        _httpService.Setup(r => r.GetAsync(It.IsAny<string>()))
            .Returns(Task.FromResult("test"));
        await Task.Delay(300);
        _httpService.Verify(r => r.GetAsync(It.IsAny<string>()), Times.AtLeast(3));
    }
    
    [Fact]
    private async Task GetMotd_Test()
    {
        _httpService.Setup(r => r.GetAsync(It.IsAny<string>()))
            .Returns(Task.FromResult("test"));
        _maniaLinkManager.Setup(r => r.SendManialinkAsync(_player.Object, "MotdModule.MotdTemplate",
            new { isChecked = false, text = "test" }));
        
        SetupMocks();
        SetupController();
        await _motdService!.ShowAsync(_player.Object);
        
        _maniaLinkManager.Verify(r => r.SendManialinkAsync(_player.Object, "MotdModule.MotdTemplate", 
            It.IsAny<object>()), Times.Once);
    }

    [Fact]
    private async Task GetMotdThrow_Test()
    {
        _httpService.Setup(r => r.GetAsync(It.IsAny<string>()))
            .Throws(new InvalidOperationException());
        
        SetupController();
        await _motdService!.GetMotdAsync();
        
        _httpService.Verify(r => r.GetAsync(It.IsAny<string>()),
            Times.Once);
    }
    
    [Fact]
    private async Task ShowAsync_Test()
    {
        _maniaLinkManager.Setup(r => r.SendManialinkAsync(_player.Object, "MotdModule.MotdTemplate",
            It.IsAny<object>())).Returns(Task.CompletedTask);
        
        SetupMocks();
        SetupController();
        await Task.Delay(500);
        await _motdService!.ShowAsync(_player.Object);
        
        _maniaLinkManager.Verify(r => r.SendManialinkAsync(_player.Object, "MotdModule.MotdTemplate", 
            It.IsAny<object>()), Times.Once);
    }
    
    [Fact]
    private async Task ShowAsyncLogin_Test()
    {
        _maniaLinkManager.Setup(r => r.SendManialinkAsync(_player.Object, "MotdModule.MotdTemplate",
            It.IsAny<object>())).Returns(Task.CompletedTask);
        _playerManager.Setup(r => r.GetPlayerAsync(It.IsAny<string>()))
            .Returns(Task.FromResult((IPlayer?)_player.Object));
        
        SetupMocks();
        SetupController();
        await Task.Delay(500);
        await _motdService!.ShowAsync("F4aNYLSUS4iB3_Td_a4c8Q", true);
        
        _maniaLinkManager.Verify(r => r.SendManialinkAsync(_player.Object, "MotdModule.MotdTemplate", 
            It.IsAny<object>()), Times.Once);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    private async Task ShowAsyncNotExplicitly_Test(bool isHidden)
    {
        _maniaLinkManager.Setup(r => r.SendManialinkAsync(_player.Object, "MotdModule.MotdTemplate",
            It.IsAny<object>())).Returns(Task.CompletedTask);
        _repository.Setup(r => r.GetEntryAsync(It.IsAny<IPlayer>()))
            .Returns(Task.FromResult(new MotdEntry { Hidden = isHidden }));
        
        SetupMocks();
        SetupController();
        await Task.Delay(500);
        await _motdService!.ShowAsync(_player.Object, false);
        
        _maniaLinkManager.Verify(r => r.SendManialinkAsync(_player.Object, "MotdModule.MotdTemplate", 
            It.IsAny<object>()), (isHidden) ? Times.Never : Times.Once);
    }
    
    [Fact]
    private async Task ShowAsyncPlayerNull_Test()
    {
        SetupMocks();
        SetupController();
        await Task.Delay(500);
        await _motdService!.ShowAsync((IPlayer)null, false);
        
        _maniaLinkManager.Verify(r => r.SendManialinkAsync(_player.Object, "MotdModule.MotdTemplate", 
            It.IsAny<object>()), Times.Never);
    }

    [Fact]
    private void Dispose_Test()
    {
        SetupController();
        _motdService.Dispose();
        Assert.True(_motdService.IsDisposed);
    } 
}
