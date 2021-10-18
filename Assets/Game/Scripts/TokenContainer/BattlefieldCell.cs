using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class BattlefieldCell : TokenContainer, IStatable
{

    public event Action<StateType> StateStarted;
    public event Action<StateType> StateEnded;

    public static float PhisicalWidth => ProceduralGeneratedMeshes.BattlefieldCellGeneration.PhisicalNormalizedWidth * 2f;
    public static float PhisicalLenght => ProceduralGeneratedMeshes.BattlefieldCellGeneration.PhisicalNormalizedWidth * 2f;

    public void StartState(StateType state)
    {
        StateStarted?.Invoke(state);
    }

    public void EndState(StateType state)
    {
        StateEnded?.Invoke(state);
    }
}
