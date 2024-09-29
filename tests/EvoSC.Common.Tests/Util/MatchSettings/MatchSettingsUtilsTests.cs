using EvoSC.Common.Util.MatchSettings;
using EvoSC.Common.Util.MatchSettings.Models.ModeScriptSettingsModels;
using Xunit;

namespace EvoSC.Common.Tests.Util.MatchSettings;

public class MatchSettingsUtilsTests
{
    [Fact]
    public void GetDefaultSettings()
    {
        var settings = new CupModeScriptSettings();

        settings.GetDefaultSettings();
    }
}
