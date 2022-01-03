using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(ICellPanel))]
public sealed class CellPanelPresenter : MonoBehaviour
{
    [SerializeField] private BillboardPresenter _accept;
    [SerializeField] private BillboardPresenter _cancel;
    [SerializeField] private BillboardPresenter _clockwiseRotation;
    [SerializeField] private BillboardPresenter _counterclockwiseRotation;

    private Coroutine _destinationChangingCoroutine;
    private int _visibilityChangingEntriesCount = 0;

    private ICellPanel _panel;

    private void Awake()
    {
        _panel = GetComponent<ICellPanel>();
    }

    private void OnEnable()
    {
        _panel.DestinationChanged += OnDestinationChanged;
        _panel.BecomeUnvisible += OnBecomeInvisible;
        _panel.ConfigChanged += OnConfigChanged;
    }

    private void OnDisable()
    {
        _panel.DestinationChanged -= OnDestinationChanged;
        _panel.BecomeUnvisible -= OnBecomeInvisible;
        _panel.ConfigChanged -= OnConfigChanged;
    }

    private void OnBecomeInvisible()
    {
        _accept.Hide();
        _cancel.Hide();
        _clockwiseRotation.Hide();
        _counterclockwiseRotation.Hide();
    }

    private void OnConfigChanged(CellPanelConfig value)
    {
        if (_panel.Visible)
            UpdateVisibilytyByConfig(value);
    }

    private void UpdateVisibilytyByConfig(CellPanelConfig value)
    {
        if (value.AcceptButtonEnabled)
            _accept.Reveal();
        else
            _accept.Hide();

        if (value.CancelButtonEnabled)
            _cancel.Reveal();
        else
            _cancel.Hide();

        if (value.RotateButtonEnabled)
        {
            _clockwiseRotation.Reveal();
            _counterclockwiseRotation.Reveal();
        }
        else
        {
            _clockwiseRotation.Reveal();
            _counterclockwiseRotation.Reveal();
        }
    }

    private void OnDestinationChanged(BattlefieldCell value)
    {
        StopCoroutines();
        _destinationChangingCoroutine = StartCoroutine(DestinationChanging(value));
    }

    private void StopCoroutines()
    {
        if (_destinationChangingCoroutine == null)
            return;

        UnsubscribeFromPresenter(_accept);
        UnsubscribeFromPresenter(_cancel);
        UnsubscribeFromPresenter(_clockwiseRotation);
        UnsubscribeFromPresenter(_counterclockwiseRotation);
        StopCoroutine(_destinationChangingCoroutine);
        _visibilityChangingEntriesCount = 0;
    }

    private void UnsubscribeFromPresenter(BillboardPresenter presenter)
    {
        presenter.VisibilityChangingFinished -= OnVisibilityEntryFinished;
    }

    private IEnumerator DestinationChanging(BattlefieldCell cell)
    {
        LaunchHiding();
        while (_visibilityChangingEntriesCount != 0)
            yield return null;

        this.transform.position = cell.transform.position;

        LaunchRevealing();
        while (_visibilityChangingEntriesCount != 0)
            yield return null;

        _destinationChangingCoroutine = null;
    }

    private void LaunchHiding()
    {
        if (_panel.Config.AcceptButtonEnabled)
            LaunchHidingEntry(_accept);
        if (_panel.Config.CancelButtonEnabled)
            LaunchHidingEntry(_cancel);
        if (_panel.Config.RotateButtonEnabled)
        {
            LaunchHidingEntry(_clockwiseRotation);
            LaunchHidingEntry(_counterclockwiseRotation);
        }
    }

    private void LaunchRevealing()
    {
        if (_panel.Config.AcceptButtonEnabled)
            LaunchRevealingEntry(_accept);
        if (_panel.Config.CancelButtonEnabled)
            LaunchRevealingEntry(_cancel);
        if (_panel.Config.RotateButtonEnabled)
        {
            LaunchRevealingEntry(_clockwiseRotation);
            LaunchRevealingEntry(_counterclockwiseRotation);
        }
    }

    private void LaunchRevealingEntry(BillboardPresenter presenter)
    {
        Debug.Log(presenter.gameObject);
        _visibilityChangingEntriesCount++;
        presenter.VisibilityChangingFinished += OnVisibilityEntryFinished;
        presenter.Reveal();

    }

    private void LaunchHidingEntry(BillboardPresenter presenter)
    {
        Debug.Log("hide" + presenter.gameObject);
        _visibilityChangingEntriesCount++;
        presenter.VisibilityChangingFinished += OnVisibilityEntryFinished;
        presenter.Hide();
    }

    private void OnVisibilityEntryFinished(BillboardPresenter presenter)
    {
        presenter.VisibilityChangingFinished -= OnVisibilityEntryFinished;
        _visibilityChangingEntriesCount--;
    }
}
