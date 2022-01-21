using System;

public interface IToken
{
    PlayerConfig PlayerConfig { get; }
    TokenData Data { get; }
    TokenGeometry Geometry { get; }

    event Action<PlayerConfig> PlayerConfigChanged;
    event Action<AzimuthTokenPresentationState> AzimuthCameraStateChanged;
}