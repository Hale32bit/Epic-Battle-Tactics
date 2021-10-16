using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using Zenject;

public class PreCameraPlane : TokenContainer
{
    private Camera _camera;

    [Inject]
    private void Construct(Camera camera)
    {
        _camera = camera;
    }

    private void Start()
    {
        var fulscreenViewport = new Rect(0, 0, 1, 1);
        var corners = new Vector3[4];
        _camera.CalculateFrustumCorners(fulscreenViewport, 1, Camera.MonoOrStereoscopicEye.Mono, corners);
       
        
    }

}
