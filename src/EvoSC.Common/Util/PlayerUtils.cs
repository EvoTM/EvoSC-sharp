﻿namespace EvoSC.Common.Util;

public class PlayerUtils
{
    /// <summary>
    /// Convert a Trackmania player's account ID to the old "login" format.
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns></returns>
    public static string ConvertAccountIdToLogin(string accountId)
    {
        var bytes = Convert.FromHexString(accountId.Replace("-", ""));

        return Convert.ToBase64String(bytes)
            .Replace("=", "")
            .Replace("+", "-")
            .Replace("/", "_");
    }

    /// <summary>
    /// Convert a Trackmania player's old "login" format to the account ID format.
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    public static string ConvertLoginToAccountId(string login)
    {
        var base64 = login
            .Replace("-", "+")
            .Replace("_", "/");

        for (int i = 0; i < login.Length % 4; i++)
        {
            base64 += "=";
        }
        
        var bytes = Convert.FromBase64String(base64);
        
        var accountId = Convert.ToHexString(bytes[0..4])
            + "-"
            + Convert.ToHexString(bytes[4..6])
            + "-"
            + Convert.ToHexString(bytes[6..8])
            + "-"
            + Convert.ToHexString(bytes[8..10])
            + "-"
            + Convert.ToHexString(bytes[10..16]);

        return accountId.ToLower();
    }
}
