using UnityEngine;

public interface IPreCameraTokenContainer : ITokenContainer
{
    Vector3 LocalCenter { get; }
    Transform Transform { get; }
}