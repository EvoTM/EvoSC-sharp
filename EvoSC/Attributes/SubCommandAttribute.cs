﻿using System;

namespace EvoSC.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class SubCommandAttribute : Attribute
{
    public SubCommandAttribute(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; }

    public string Description { get; }
}
