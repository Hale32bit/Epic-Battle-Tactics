using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(TokenPresentationPanel))]
public class TokenPresentationPanelView : MonoBehaviour
{
    [SerializeField] private Image _edge;
    [SerializeField] private RawImage _picture;
    [SerializeField] private RawImage _iconographic;
    [SerializeField] private RawImage _iconographic2;

    private TokenPresentationPanel _panel;

    private void Awake()
    {
        _panel = GetComponent<TokenPresentationPanel>();
        _panel.Closed += OnClosed;
        _panel.TokenSelected += OnLaunched;
    }

    private void OnDestroy()
    {
        _panel.Closed -= OnClosed;
        _panel.TokenSelected -= OnLaunched;
    }

    private void OnClosed()
    {
    }

    internal void OnLaunched(IToken token)
    {
        _edge.color = token.PlayerConfig.Color;
        _picture.texture = token.Data.MainTexture;
        _iconographic.texture = token.Data.IconographicTexture;
        _iconographic2.texture = token.Data.IconographicTextureRotatable;
    }
}
