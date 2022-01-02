using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public sealed class CameraRotationModel : MonoBehaviour
{
    public const int NumberOfSteps = 4;
    public const float DegreesPerStep = 360f / (float)NumberOfSteps;

    public event Action ForeshorteningChanged;

    public int ForeshorteningStep { get; private set; } = 0;

    public float TargetCameraAzimuth => (float)ForeshorteningStep * DegreesPerStep;

    public void NextForeshorteningToRight() => SetForeshortening(ForeshorteningStep + 1);

    public void NextForeshorteningToLeft() => SetForeshortening(ForeshorteningStep - 1);
    
    private void SetForeshortening(int newForeshortening)
    {
        ForeshorteningStep = newForeshortening % NumberOfSteps;
        ForeshorteningChanged?.Invoke();
    }
}