using System;

internal interface ITokenRotatable
{
    int RotationStep { get; }

    event Action RotationStepChanged;

    void SetRotationInProcess(bool value);
}