using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(BoxCollider), typeof(TokenGeometry))]
[DisallowMultipleComponent]
public class Token : WorldPointerHandler, ITokenRotatable, IToken
{
    public const int RotationStepsCount = 4;

    public event Action MovementStarted;
    public event Action RotationStepChanged;
    public event Action<AzimuthTokenPresentationState> AzimuthCameraStateChanged;
    public event Action<PlayerConfig> PlayerConfigChanged;

    [SerializeField] private TokenData _tokenData;
    public TokenData Data => _tokenData;

    public int RotationStep { get; private set; }
    public TokenGeometry Geometry { get; private set; }
    public PlayerConfig PlayerConfig { get; private set; }

    [Inject]
    private void Construct(PlayerConfig playerConfig)
    {
        PlayerConfig = playerConfig;
    }

    private void Awake()
    {
        Geometry = GetComponent<TokenGeometry>();
    }

    private void Start()
    {
        PlayerConfigChanged?.Invoke(PlayerConfig);
    }

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
