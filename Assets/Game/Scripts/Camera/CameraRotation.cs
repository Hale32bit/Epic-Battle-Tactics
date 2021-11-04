using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(CameraRotationModel))]
public sealed class CameraRotation : MonoBehaviour
{
    private CameraRotationModel _model;

    private float _targetAngle = 0;

    [SerializeField] private  float _rotationSpeed = 150;

    private void Awake()
    {
        _model = GetComponent<CameraRotationModel>();
        _model.ForeshorteningChanged += OnForeshorteningChanged;
        //this.enabled = false;

        Debug.Log("hi");
    }

    private void OnDestroy()
    {
        _model.ForeshorteningChanged -= OnForeshorteningChanged;
    }

    private void OnForeshorteningChanged()
    {
        const float anglePerStep = 90f;
        _targetAngle = (float)_model.ForeshorteningStep * anglePerStep;
        this.enabled = true;
    }

    private void Update()
    {
        float currentAngle = this.transform.rotation.eulerAngles.y;

        float newAngle = Mathf.MoveTowardsAngle(currentAngle, _targetAngle, Time.deltaTime * _rotationSpeed);
        transform.rotation = Quaternion.Euler(0, newAngle, 0);

        if (newAngle == _targetAngle)
            this.enabled = false;
    }
}

