using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerConfig 
{
    private Color _color;
    private string _name;

    public PlayerConfig(Color color, string name)
    {
        _color = color;
        _name = name;
    }
}
