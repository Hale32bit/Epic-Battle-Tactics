using System;

internal interface IToken
{
    PlayerConfig PlayerConfig { get; }
    TokenData Data { get; }

    event Action<PlayerConfig> PlayerConfigChanged;
    event Action<AzimuthTokenPresentationState> AzimuthCameraStateChanged;
}