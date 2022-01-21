using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(TokenPresentationPanel))]
public class TokenPresentationPanelApperance : MonoBehaviour
{
    [SerializeField] private Image _panelImage;
    [SerializeField] private float _openingDuration = 0.2f;
    [SerializeField] private float _closingDuration = 0.2f;
    [SerializeField] private AnimationCurve _openingScaleVsNormalizedTime;
    [SerializeField] private AnimationCurve _closingScaleVsNormalizedTime;

    private Coroutine _activeCoroutine;

    private TokenPresentationPanel _panel;

    private void Awake()
    {
        _panel = GetComponent<TokenPresentationPanel>();
        _panel.Closed += OnClosed;
        _panel.TokenSelected += OnOpened;
    }

    private void OnDestroy()
    {
        _panel.Closed -= OnClosed;
        _panel.TokenSelected -= OnOpened;
    }

    private void OnOpened(IToken obj)
    {
        StopCoroutine();
        _activeCoroutine = StartCoroutine(ScaleChanging(_openingDuration, _openingScaleVsNormalizedTime));
    }

    private void OnClosed()
    {
        StopCoroutine();
        _activeCoroutine = StartCoroutine(ScaleChanging(_closingDuration, _closingScaleVsNormalizedTime));
    }

    private void StopCoroutine()
    {
        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
            _activeCoroutine = null;
        }
    }

    private IEnumerator ScaleChanging(float duration, AnimationCurve scaleVsNormalizedTime)
    {
        float startTime = Time.time;
        float normalizedTime = 0;
        while (normalizedTime < 1)
        {
            normalizedTime = (Time.time - startTime) / duration;
            if (normalizedTime > 1)
                normalizedTime = 1;

            float normalizedScale = scaleVsNormalizedTime.Evaluate(normalizedTime);
            _panelImage.transform.localScale = Vector3.one * normalizedScale;
            yield return null;
        }

        _activeCoroutine = null;
    }

}
