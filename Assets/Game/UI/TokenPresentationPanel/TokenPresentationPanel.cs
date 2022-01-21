using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[DisallowMultipleComponent]
public sealed class TokenPresentationPanel : MonoBehaviour
{
    public event Action<IToken> TokenSelected;
    public event Action Closed;

    public IToken SelectedToken { get; private set; } = null;

    private WorldPointerHandler_new _pointerHandler;

    [Inject]
    private void Construct(WorldPointerHandler_new pointerHandler)
    {
        _pointerHandler = pointerHandler;
    }

    private void Awake()
    {
        _pointerHandler.Clicked += OnClicked;
    }

    private void OnDestroy()
    {
        _pointerHandler.Clicked -= OnClicked;
    }

    private void OnClicked(WorldPointerEventDataNew data)
    {
        if (data.EventType == WorldPointerEventType.RightClick &&
            data.Object != null &&
            data.Object.TryGetComponent<IToken>(out IToken token))
        {
            LauchPanel(token);
            return;
        }

        if (data.Object != null &&
            data.Object.Is<TokenPresentationPanel>())
            return;
        
        ClosePanel();
    }

    private void LauchPanel(IToken token)
    {
        SelectedToken = token;
        TokenSelected?.Invoke(SelectedToken);
    }

    private void ClosePanel()
    {
        if (SelectedToken != null)
        {
            SelectedToken = null;
            Closed?.Invoke();
        }
    }
}
