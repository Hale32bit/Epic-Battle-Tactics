using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(CellPanel))]
public sealed class CellPanelPresenter : MonoBehaviour
{
    [SerializeField] private float _alphaChangingSpeed = 3f;
    [SerializeField] private BilboardView[] _billboardsViews;    

    private float _currentAlpha = 1f;
    private Coroutine _destinationChangingCoroutine;
    private Coroutine _visibilityCoroutine;

    private CellPanel _panel;

    private void Awake()
    {
        _panel = GetComponent<CellPanel>();
    }

    private void OnEnable()
    {
        _panel.DestinationChanged += OnDestinationChanged;
        _panel.VisibleChanged += OnVisibleChanged;
    }

    private void OnDisable()
    {
        _panel.DestinationChanged -= OnDestinationChanged;
        _panel.VisibleChanged -= OnVisibleChanged;
    }

    private void OnVisibleChanged(bool value)
    {
        if (_destinationChangingCoroutine != null)
            return;

        LaunchVisibleChanging();
    }

    private void LaunchVisibleChanging()
    {
        StopCoroutines();
        _visibilityCoroutine = StartCoroutine(VisibilityChanging(_panel.Visible ? 1f : 0f));
    }

    private void OnDestinationChanged(BattlefieldCell value)
    {
        StopCoroutines();
        _destinationChangingCoroutine = StartCoroutine(DestinationChanging(value));
    }

    private void StopCoroutines()
    {
        if (_destinationChangingCoroutine != null)
            StopCoroutine(_destinationChangingCoroutine);
        if (_visibilityCoroutine != null)
            StopCoroutine(_visibilityCoroutine);
    }

    private IEnumerator DestinationChanging(BattlefieldCell cell)
    {
        _visibilityCoroutine = StartCoroutine(VisibilityChanging(0f));
        yield return _visibilityCoroutine;

        this.transform.position = cell.transform.position;

        _visibilityCoroutine = StartCoroutine(VisibilityChanging(1f));
        yield return _visibilityCoroutine;

        _destinationChangingCoroutine = null;
    }

    private IEnumerator VisibilityChanging(float destination)
    {
        DisableColliders();
        
        while (_currentAlpha != destination)
        {
            UpdateAlpha(destination);
            yield return null;
        }

        if (_panel.Visible)
            EnableColliders();

        _visibilityCoroutine = null;
    }

    private void DisableColliders()
    {
        foreach (var view in _billboardsViews)
            view.ColliderOFF();
    }

    private void EnableColliders()
    {
        foreach (var view in _billboardsViews)
            view.ColliderON();
    }

    private void UpdateAlpha(float destination)
    {
        _currentAlpha = Mathf.MoveTowards(_currentAlpha, destination, _alphaChangingSpeed * Time.deltaTime);
        foreach (var view in _billboardsViews)
            view.SetAlpha(_currentAlpha);
    }
}
