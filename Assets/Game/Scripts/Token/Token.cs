using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(BoxCollider))]
[DisallowMultipleComponent]
public class Token : WorldPointerHandler, ITokenRotatable
{
    public const int RotationStepsCount = 4;

    public event Action MovementStarted;
    public event Action RotationStepChanged;
    public event Action<AzimuthTokenPresentationState> AzimuthCameraStateChanged;

    [SerializeField] private TokenTextureAzimuthPresenter _azimuthPresenter;
    
    public int RotationStep { get; private set; }

    public void SetCameraAzimuthState()
    {
        AzimuthCameraStateChanged?.Invoke(AzimuthTokenPresentationState.Camera);
    }

    public void SetSimpleAzimuthState()
    {
        AzimuthCameraStateChanged?.Invoke(AzimuthTokenPresentationState.Simple);
    }

    public void SetRotationStep(int value)
    {
        RotationStep = value % RotationStepsCount;
        RotationStepChanged?.Invoke();
    }

    public void SetMovementStarted()
    {
        MovementStarted?.Invoke();
    }

    public class Factory : PlaceholderFactory<Token> { }
}
