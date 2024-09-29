using System.ComponentModel;
using System.Reflection;
using EvoSC.Common.Util.MatchSettings.Attributes;
using EvoSC.Common.Util.MatchSettings.Models;

namespace EvoSC.Common.Util.MatchSettings;

public static class MatchSettingsUtils
{
    public static Dictionary<string, ModeScriptSettingInfo> GetDefaultSettings(this ModeScriptSettings script)
    {
        var type = script.GetType();
        var scriptName = type.GetCustomAttribute<ScriptSettingsForAttribute>().Name;

        var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
        var settingsDict = new Dictionary<string, ModeScriptSettingInfo>();

        foreach (var prop in properties)
        {
            var baseProperty = typeof(ModeScriptSettings).GetProperty(prop.Name, BindingFlags.Instance | BindingFlags.NonPublic);

            if (baseProperty == null)
            {
                var settingsAttr = prop.GetCustomAttribute<ScriptSettingAttribute>();
                settingsDict.Add(settingsAttr.Name ?? $"S_{prop.Name}", new ModeScriptSettingInfo
                {
                    Value = null,
                    Description = "",
                    Type = prop.PropertyType
                });
            }
            else
            {
                var settingsAttr = baseProperty.GetCustomAttribute<ScriptSettingAttribute>();
                var descAttr = baseProperty.GetCustomAttribute<DescriptionAttribute>();
                var defaultValueAttrs = baseProperty.GetCustomAttributes<DefaultScriptSettingValueAttribute>();
                object? defaultValue = defaultValueAttrs.FirstOrDefault(a => a.OnMode == scriptName)?.Value;

                settingsDict.Add(settingsAttr.Name ?? $"S_{prop.Name}",
                    new ModeScriptSettingInfo
                    {
                        Value = defaultValue,
                        Description = descAttr?.Description ?? "",
                        Type = baseProperty.PropertyType
                    });
            }
        }
        
        return new Dictionary<string, ModeScriptSettingInfo>();
    }
}
