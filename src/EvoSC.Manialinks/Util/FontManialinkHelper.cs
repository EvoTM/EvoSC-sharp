﻿using EvoSC.Common.Interfaces.Themes;

namespace EvoSC.Manialinks.Util;

public class FontManialinkHelper
{
    private readonly dynamic _theme;

    /// <summary>
    /// Thin thickness of the current font.
    /// </summary>
    public string Thin => ToThin(_theme.UI_Font);
    
    /// <summary>
    /// Regular thickness of the current font.
    /// </summary>
    public string Regular => ToRegular(_theme.UI_Font);
    
    /// <summary>
    /// Bold thickness of the current font.
    /// </summary>
    public string Bold => ToBold(_theme.UI_Font);
    
    /// <summary>
    /// Extra bold thickness of the current font.
    /// </summary>
    public string ExtraBold => ToExtraBold(_theme.UI_Font);
    
    /// <summary>
    /// Mono version of the current font.
    /// </summary>
    public string Mono => ToExtraBold(_theme.UI_Font);
    
    public FontManialinkHelper(IThemeManager theme)
    {
        _theme = theme.Theme;
    }
    
    /// <summary>
    /// Convert the provided font to it's regular thickness version.
    /// </summary>
    /// <param name="font">Font to convert.</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public string ToRegular(string font) => font switch
    {
        _ when font.StartsWith("GameFont") => "GameFontSemiBold",
        _ when font.StartsWith("Rajdhani") => "RajdhaniMono",
        _ when font.StartsWith("Oswald") => "Oswald",
        _ when font.StartsWith("Roboto") => "RobotoCondensed",
        _ => throw new InvalidOperationException("Invalid font.")
    };

    /// <summary>
    /// Convert the provided font to it's thin thickness version.
    /// </summary>
    /// <param name="font">Font to convert.</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public string ToThin(string font) => font switch
    {
        _ when font.StartsWith("GameFont") => "GameFontSemiRegular",
        _ => ToRegular(font)
    };
    
    /// <summary>
    /// Convert the provided font to it's bold thickness version.
    /// </summary>
    /// <param name="font">Font to convert.</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public string ToBold(string font) => font switch
    {
        _ when font.StartsWith("GameFont") => "GameFontExtraBold",
        _ when font.StartsWith("Roboto") => "RobotoCondensedBold",
        _ => ToRegular(font)
    };
    
    /// <summary>
    /// Convert the provided font to it's extra bold thickness version.
    /// </summary>
    /// <param name="font">Font to convert.</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public string ToExtraBold(string font) => font switch
    {
        _ when font.StartsWith("GameFont") => "GameFontBlack",
        _ => ToBold(font)
    };
    
    /// <summary>
    /// Convert the provided font to it's mono version.
    /// </summary>
    /// <param name="font">Font to convert.</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public string ToMono(string font) => font switch
    {
        _ when font.StartsWith("Rajdhani") => "RajdhaniMono",
        _ when font.StartsWith("Oswald") => "OswaldMono",
        _ => ToRegular(font)
    };
}
