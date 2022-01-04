using PlasticPipe.PlasticProtocol.Server.Stubs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(ITokenRotatable))]
public class TokenRotator : MonoBehaviour
{
    public event Action Finished;

    [SerializeField] private float _jumpDuration = 0.8f;
    [SerializeField] private float _jumpHeight = 1f;
    [SerializeField] private AnimationCurve _normalizedHeightVsNormalizedTime;

    private Coroutine _activeCoroutine;
    private float _coroutineJumpElapsedTime;
    private float _currentAngle;
    private Vector3 _basicPoint;

    private ITokenRotatable _token;

    private void Awake()
    {
        _token = GetComponent<ITokenRotatable>();
    }

    private void OnEnable()
    {
        _token.RotationStepChanged += OnRotationStepChanged;
        _token.MovementStarted += StopRotation;
    }

    private void OnDisable()
    {
        _token.RotationStepChanged -= OnRotationStepChanged;
        _token.MovementStarted -= StopRotation;
    }

    private void StopRotation()
    {
        _currentAngle = 0;
        //_basicPoint = this.transform.position;
        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
            _activeCoroutine = null;
        }
    }

    private void OnRotationStepChanged()
    {
        float destinationAngel = _token.RotationStep * (float)(360 / Token.RotationStepsCount);

        if (_activeCoroutine != null)
            RelaunchCurrentRotation(destinationAngel);
        else
            LaunchNewRotation(destinationAngel);
    }

    private void RelaunchCurrentRotation(float destinationAngel)
    {
        StopCoroutine(_activeCoroutine);

        ReturnTofirstHalfOfJump();

        _activeCoroutine = StartCoroutine(Rotation(destinationAngel));
    }

    private void ReturnTofirstHalfOfJump()
    {
        if (_coroutineJumpElapsedTime > _jumpDuration / 2f)
        {
            float delta = _coroutineJumpElapsedTime - _jumpDuration / 2f;
            _coroutineJumpElapsedTime = _jumpDuration / 2f  - delta;
        }
    }

    private void LaunchNewRotation(float destinationAngel)
    {
        _basicPoint = this.transform.position;
        _coroutineJumpElapsedTime = 0;
        _activeCoroutine = StartCoroutine(Rotation(destinationAngel));
    }

    private IEnumerator Rotation(float destination)
    {
        float startAngle = _currentAngle;
        float rotationElapsetTime = 0;
        float rotationDuration = _jumpDuration - _coroutineJumpElapsedTime;

        while (_coroutineJumpElapsedTime < _jumpDuration)
        {
            _coroutineJumpElapsedTime += Time.deltaTime;
            rotationElapsetTime += Time.deltaTime;
            _currentAngle = Mathf.LerpAngle(startAngle, destination, rotationElapsetTime / rotationDuration);
            float currentHeight = _normalizedHeightVsNormalizedTime.Evaluate(_coroutineJumpElapsedTime / _jumpDuration) * _jumpHeight;
            this.transform.position = _basicPoint + Vector3.up * currentHeight;
            this.transform.rotation = Quaternion.Euler(0f, _currentAngle, 0f);
            yield return null;
        }
        _activeCoroutine = null;
    }
}
