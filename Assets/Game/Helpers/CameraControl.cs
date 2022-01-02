using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;
using Zenject;

[DisallowMultipleComponent]
public class CameraControl : MonoBehaviour
{
    private const float MovingSpeed = 1f;
    private const float RotatingSpeed = 2f;

    private Transform _camera;
    private InputAction _moveAction;
    private InputAction _rotateAction;

    private Vector3 _movingVector;
    private float _rotatingAxis;

    [SerializeField] private CameraRotationModel RotationModel;

    [Inject]
    private void Construct(InputActions inputActions, Camera camera)
    {
        _moveAction = inputActions.Player.Move;
        _rotateAction = inputActions.Player.Rotation;
        _camera = camera.transform;
    }

    private void OnEnable()
    {
        _rotateAction.performed += OnRotate;
        _rotateAction.started += OnRotate;
        _rotateAction.canceled += OnRotate;
        _rotateAction.Enable();
       
        _moveAction.performed += OnMove;
        _moveAction.started += OnMove;
        _moveAction.canceled += OnMove;
        _moveAction.Enable();
    }

    private void OnDisable()
    {
        _rotateAction.performed -= OnRotate;
        _rotateAction.started -= OnRotate;
        _rotateAction.canceled -= OnRotate;
        _rotateAction.Disable();

        _moveAction.performed -= OnMove;
        _moveAction.started -= OnMove;
        _moveAction.canceled -= OnMove;
        _moveAction.Disable();
    }

    private void OnMove(InputAction.CallbackContext obj)
    {
        Vector2 newValue = obj.action.ReadValue<Vector2>();
        _movingVector = new Vector3(newValue.x, 0f, newValue.y);
    }

    private void OnRotate(InputAction.CallbackContext obj)
    {
        // _rotatingAxis = obj.action.ReadValue<float>();
        var actionValue = obj.action.ReadValue<float>();
        Debug.Log("hi");

        if (actionValue > 0)
            RotationModel.NextForeshorteningToRight();
        if (actionValue < 0)
            RotationModel.NextForeshorteningToLeft();

    }

    void Update()
    {
        _camera.position += _movingVector * MovingSpeed * Time.deltaTime;
        _camera.Rotate(0, _rotatingAxis * RotatingSpeed * Time.deltaTime , 0);
    }
}
