﻿using System.Reflection;

namespace EvoSC.Common.Util.EnumIdentifier;

public static class EnumIdentifierUtils
{
    /// <summary>
    /// Get the "prefix" which identifies a permission group.
    /// </summary>
    /// <param name="enumType">Type of the enumeration.</param>
    /// <returns></returns>
    private static string GetIdentifierPrefix(Type enumType)
    {
        var customName = enumType.GetCustomAttribute<IdentifierAttribute>()?.Name;

        if (customName == null)
        {
            return enumType.Name;
        }

        return customName;
    }

    /// <summary>
    /// Get the ID name from an enum value as a string representation.
    /// The value can also annotate IdentifierAttribute for alternative custom names.
    /// </summary>
    /// <param name="enumValue">Enum value to get ID name from.</param>
    /// <param name="noPrefix">If true, force no prefix, otherwise use the attribute's value.</param>
    /// <returns></returns>
    public static string GetIdentifier(this Enum enumValue, bool noPrefix)
    {
        if (enumValue == null)
        {
            throw new InvalidOperationException("Identifier must be an enum or not null.");
        }
        
        var enumType = enumValue.GetType();
        var fieldDefName = enumValue.ToString();
        var enumMember = enumType.GetMember(fieldDefName).FirstOrDefault();
        var ident = enumMember?.GetCustomAttribute<IdentifierAttribute>();
        var actualName = ident?.Name ?? fieldDefName;

        if (!noPrefix && (ident == null || !ident.NoPrefix))
        {
            return GetIdentifierPrefix(enumType) + "." + actualName;
        }

        return actualName;
    }

    /// <summary>
    /// Get the ID name from an enum value as a string representation.
    /// The value can also annotate IdentifierAttribute for alternative custom names.
    /// </summary>
    /// <param name="enumValue">Enum value to get ID name from.</param>
    /// <returns></returns>
    public static string GetIdentifier(this Enum enumValue) => GetIdentifier(enumValue, false);

    /// <summary>
    /// Convert an object to an enumeration value. This method also verifies that
    /// it is one and throws an exception if not.
    /// </summary>
    /// <param name="obj">Object value to convert to an enum value.</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">Thrown if the conversion failed.</exception>
    public static Enum AsEnum(this object obj)
    {
        if (obj is not Enum enumValue)
        {
            throw new InvalidOperationException(
                "Value is not an enumeration value. Are you trying to pass a non-enum object to a enumeration parameter?");
        }

        return enumValue;
    }

    /// <summary>
    /// Get a list of aliases for this enum value.
    /// </summary>
    /// <param name="enumValue">The enum value to get aliases of.</param>
    /// <returns></returns>
    public static IEnumerable<string> GetAliases(this Enum enumValue)
    {
        var enumType = enumValue.GetType();
        var fieldDefName = enumValue.ToString();
        var enumMember = enumType.GetMember(fieldDefName).FirstOrDefault();

        var aliases = enumMember?.GetCustomAttributes<AliasAttribute>().Select(a => a.Name);

        return aliases ?? Array.Empty<string>();
    }

    /// <summary>
    /// Get the enumeration value that corresponds to the specified identifier.
    /// </summary>
    /// <param name="identifier">The identifier to find the value of.</param>
    /// <typeparam name="T">The enum type to search in.</typeparam>
    /// <returns></returns>
    public static T? ToEnumValue<T>(this string identifier) where T : struct, Enum
    {
        foreach (var value in Enum.GetValues<T>())
        {
            if (value.GetIdentifier().Equals(identifier, StringComparison.Ordinal))
            {
                return value;
            }
        }

        return null;
    }
}
