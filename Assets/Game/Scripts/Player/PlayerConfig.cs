using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerConfig 
{
    public Color Color { get; private set; }
    public string Name { get; private set; }

    public PlayerConfig(Color color, string name)
    {
        Color = color;
        Name = name;
    }
}
