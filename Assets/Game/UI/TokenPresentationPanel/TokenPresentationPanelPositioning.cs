using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(TokenPresentationPanel))]
public class TokenPresentationPanelPositioning : MonoBehaviour
{
    [SerializeField] private Image _panelImage;

    private TokenPresentationPanel _panel;

    private void Awake()
    {
        _panel = GetComponent<TokenPresentationPanel>();
        _panel.TokenSelected += OnSelected;
    }

    private void OnDestroy()
    {
        _panel.TokenSelected -= OnSelected;
    }

    private void OnSelected(IToken obj)
    {
        Update();
    }

    private void Update()
    {
        if (_panel.SelectedToken != null)
        _panelImage.rectTransform.position = 
                new Vector3(_panel.SelectedToken.Geometry.ScreenMinX, _panel.SelectedToken.Geometry.ScreenMinY, 0);
    }
}
