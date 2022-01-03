using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BilboardView))]
public class BillboardPresenter : MonoBehaviour
{
    public event Action<BillboardPresenter> VisibilityChangingFinished;

    [SerializeField] private float _alphaChangingSpeed = 5f;

    public bool Visible { get; private set; } = false;
    private float _currentAlpha;
    private Coroutine _activeCoroutine;

    private BilboardView _view;

    private void Awake()
    {
        _view = GetComponent<BilboardView>();
    }

    public void Reveal()
    {
        if (Visible)
        {
            VisibilityChangingFinished?.Invoke(this);
            return;
        }
        
        Visible = true;
        StopCoroutine();
        _activeCoroutine = StartCoroutine(VisibilityChanging(1f));
    }

    public void Hide()
    {
        if (Visible == false)
        {
            VisibilityChangingFinished?.Invoke(this);
            return;
        }

        Visible = false;
        StopCoroutine();
        _activeCoroutine = StartCoroutine(VisibilityChanging(0f));
    }

    private void StopCoroutine()
    {
        if (_activeCoroutine != null)
            StopCoroutine(_activeCoroutine);
        _activeCoroutine = null;
    }

    private IEnumerator VisibilityChanging(float destination)
    {
        _view.ColliderOFF();

        while (_currentAlpha != destination)
        {
            UpdateAlpha(destination);
            yield return null;
        }

        if (Visible)
            _view.ColliderON();

        VisibilityChangingFinished?.Invoke(this);
        _activeCoroutine = null;
    }

    private void UpdateAlpha(float destination)
    {
        _currentAlpha = Mathf.MoveTowards(_currentAlpha, destination, _alphaChangingSpeed * Time.deltaTime);
        _view.SetAlpha(_currentAlpha);
    }
}
