using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[DisallowMultipleComponent]
public sealed class TokenTextureAzimuthPresenter : MonoBehaviour
{
    public const float DefaultAzimuth = 0f;

    private AzimuthTokenPresentationState _state = AzimuthTokenPresentationState.Simple;

    public float TargetAthimuth { get
        {
            if (_state == AzimuthTokenPresentationState.Camera)
                return  _cameraModel.TargetCameraAzimuth - transform.rotation.eulerAngles.y;
            else if (_state == AzimuthTokenPresentationState.Simple)
                return DefaultAzimuth;
            else
                throw new Exception("TargetAthimuth cant be defined");
        } }
    
    
    private CameraRotationModel _cameraModel;

    [SerializeField] private Token _token;

    [Inject]
    private void Construct(CameraRotationModel cameraModel)
    {
        _cameraModel = cameraModel;
        _state =  AzimuthTokenPresentationState.Simple;
    }

    private void OnEnable()
    {
        _token.AzimuthCameraStateChanged += OnAzimuthStateChanged;
    }

    private void OnDisable()
    {
        _token.AzimuthCameraStateChanged -= OnAzimuthStateChanged;
    }

    private void OnAzimuthStateChanged(AzimuthTokenPresentationState value)
    {
        _state = value;
    }
}