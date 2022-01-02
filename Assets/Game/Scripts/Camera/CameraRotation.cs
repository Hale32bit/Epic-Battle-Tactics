using System;
using UnityEngine;
using Zenject;

[DisallowMultipleComponent]
public sealed class CameraRotation : MonoBehaviour
{
    public event Action Updated;

    private CameraRotationModel _model;

    [SerializeField] private  float _rotationSpeed = 150;

    [Inject]
    private void Construct(CameraRotationModel model)
    {
        _model = model;
    }

    private void Awake()
    {
        _model.ForeshorteningChanged += OnForeshorteningChanged;
        this.enabled = false;
    }

    private void OnDestroy()
    {
        _model.ForeshorteningChanged -= OnForeshorteningChanged;
    }

    private void OnForeshorteningChanged()
    {
        this.enabled = true;
    }

    private void Update()
    {
        float currentAzimuth = this.transform.rotation.eulerAngles.y;

        float newAzimuth = Mathf.MoveTowardsAngle(currentAzimuth, _model.TargetCameraAzimuth, Time.deltaTime * _rotationSpeed);
        transform.rotation = Quaternion.Euler(0, newAzimuth, 0);

        Updated?.Invoke();

        if (newAzimuth == _model.TargetCameraAzimuth)
            this.enabled = false;
    }
}

