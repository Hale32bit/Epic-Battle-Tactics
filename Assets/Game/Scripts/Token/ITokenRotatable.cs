using System;

internal interface ITokenRotatable
{
    int RotationStep { get; }

    event Action RotationStepChanged;
    event Action MovementStarted;
}