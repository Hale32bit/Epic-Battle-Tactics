using PlasticPipe.PlasticProtocol.Server.Stubs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TokenRotator : MonoBehaviour
{
    public event Action Finished;

    [SerializeField] private float _duration = 0.3f;
    [SerializeField] private float _jumpHeight = 1f;
    [SerializeField] private AnimationCurve _normalizedHeightVsNormalizedTime;

    private Coroutine _activeCoroutine;
    private float _lastCoroutineStartTime;
    private Token _workingToken;

    public void SetToken(Token value)
    {
        if (_activeCoroutine != null)
            throw new System.Exception("you try set token in active phase");

        _workingToken = value;
    }

    public void RotateClockwise()
    {
       if (_activeCoroutine != null)
        {

        }
    }

    public void RotateCounterClockwise()
    {

    }

    private IEnumerator Rotation()
    {
        yield return null;

        Finished?.Invoke();
        _activeCoroutine = null;
    }

}
