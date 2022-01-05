using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[DisallowMultipleComponent]
[RequireComponent(typeof(IToken))]
public sealed class TokenQuadPresenter : MonoBehaviour, IQuadAzimuthProvider
{
    public const float DefaultAzimuth = 0f;

    [SerializeField] private QuadView _view;

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
    private IToken _token;

    [Inject]
    private void Construct(CameraRotationModel cameraModel)
    {
        _cameraModel = cameraModel;
        _state =  AzimuthTokenPresentationState.Simple;
    }

    private void Awake()
    {
        _token = GetComponent<IToken>();
        Debug.Log(_token);
    }

    private void Start()
    {
        _view.Initialize(this);
        _view.SetData(_token.Data);
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