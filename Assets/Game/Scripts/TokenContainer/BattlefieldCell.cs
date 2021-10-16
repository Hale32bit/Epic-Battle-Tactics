using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class BattlefieldCell : TokenContainer, IHiglitable
{
    public event Action Highlighted;
    public event Action HighlightedOFF;


    public static float PhisicalWidth => ProceduralGeneratedMeshes.BattlefieldCellGeneration.PhisicalNormalizedWidth * 2f;
    public static float PhisicalLenght => ProceduralGeneratedMeshes.BattlefieldCellGeneration.PhisicalNormalizedWidth * 2f;

    void IHiglitable.HiglightOFF()
    {
        HighlightedOFF?.Invoke();
    }

    void IHiglitable.HiglightON()
    {
        Highlighted?.Invoke();

    }
}
