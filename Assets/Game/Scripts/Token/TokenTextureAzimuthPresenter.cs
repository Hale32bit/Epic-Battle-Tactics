using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[DisallowMultipleComponent]
public sealed class TokenTextureAzimuthPresenter : MonoBehaviour
{
    private enum PresentationState
    {
        Simple,
        Camera
    }

    public const float DefaultAzimuth = 0f;

    public event Action TargetAzimuthChanged;

    public float TargetAthimuth { get
        {
            if (_state == PresentationState.Camera)
                return  _cameraModel.TargetCameraAzimuth - transform.rotation.eulerAngles.y;
            else if (_state == PresentationState.Simple)
                return DefaultAzimuth;
            else
                throw new Exception("TargetAthimuth cant be defined");
        } }

    
    private CameraRotationModel _cameraModel;

    private PresentationState _state = PresentationState.Simple;

    [Inject]
    private void Construct(CameraRotationModel cameraModel)
    {
        _cameraModel = cameraModel;
        SetSimpleState();
        _cameraModel.ForeshorteningChanged += OnForeshoterningChanged;
    }

    private void OnDestroy()
    {
        _cameraModel.ForeshorteningChanged -= OnForeshoterningChanged;
    }

    private void OnForeshoterningChanged()
    {
        if (_state == PresentationState.Camera)
            TargetAzimuthChanged?.Invoke();
    }

    public void SetCameraState()
    {
        _state = PresentationState.Camera;
        TargetAzimuthChanged?.Invoke();
    }

    public void SetSimpleState()
    {
        _state = PresentationState.Simple;
        TargetAzimuthChanged?.Invoke();
    }
}