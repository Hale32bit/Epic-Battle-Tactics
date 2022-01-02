using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[DisallowMultipleComponent]
public class Billboard : MonoBehaviour
{
    private Transform _camera;
    private CameraRotation _cameraRotation;

    [Inject]
    private void Construct(Camera camera, CameraRotation cameraRotation)
    {
        _camera = camera.transform;
        _cameraRotation = cameraRotation;
    }

    private void OnEnable()
    {
        _cameraRotation.Updated += OnCameraRotationUpdated;
        OnCameraRotationUpdated();
    }

    private void OnDisable()
    {
        _cameraRotation.Updated -= OnCameraRotationUpdated;
    }

    private void OnCameraRotationUpdated()
    {
        this.transform.forward = _camera.forward;
    }
}
