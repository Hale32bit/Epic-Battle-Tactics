using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[DisallowMultipleComponent]
[RequireComponent(typeof(TokenPresentationPanel))]
public sealed class TokenPresentationPanelLauncher : MonoBehaviour
{
    private IToken _selectedToken = null;

    private TokenPresentationPanel _panel;
    private WorldPointerHandler_new _pointerHandler;

    [Inject]
    private void Construct(WorldPointerHandler_new pointerHandler)
    {
        _pointerHandler = pointerHandler;
    }

    private void Awake()
    {
        _panel = GetComponent<TokenPresentationPanel>();
        _pointerHandler.Clicked += OnClicked;
    }

    private void OnDestroy()
    {
        _pointerHandler.Clicked -= OnClicked;
    }

    private void OnClicked(WorldPointerEventDataNew data)
    {
        if (data.Object!= null &&
            data.Object.TryGetComponent<IToken>(out IToken token))
            LauchPanel(token);
        else
            ClosePanel();
    }

    private void LauchPanel(IToken token)
    {
        _selectedToken = token;
        _panel.Launch(token);
        Debug.Log("launch");
    }

    private void ClosePanel()
    {
        if (_selectedToken != null)
        {
            _selectedToken = null;
            _panel.Close();
            Debug.Log("close");
        }
    }
}
