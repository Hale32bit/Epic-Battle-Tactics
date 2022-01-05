using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(IToken))]
public class TokenEdgePresenter : MonoBehaviour
{
    [SerializeField] private TokenEdgeView _view;

    private IToken _token;

    private void Awake()
    {
        _token = GetComponent<IToken>();
    }

    private void OnEnable()
    {
        _token.PlayerConfigChanged += OnPlayerConfigChanged;
    }

    private void OnDisable()
    {
        _token.PlayerConfigChanged -= OnPlayerConfigChanged;
    }

    private void OnPlayerConfigChanged(PlayerConfig value)
    {
        _view.SetColor(value.Color);
    }
}
