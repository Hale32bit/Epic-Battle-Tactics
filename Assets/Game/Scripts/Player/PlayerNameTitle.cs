using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerNameTitle : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _text;

    private IPlayerTurn _playerTurn;

    [Inject]
    private void Construct(IPlayerTurn playerTurn)
    {
        _playerTurn = playerTurn;
    }

    private void OnEnable()
    {
        _playerTurn.TurnChanged += OnTurnChanged;
    }

    private void OnDisable()
    {
        _playerTurn.TurnChanged -= OnTurnChanged;
    }

    private void Start()
    {
       OnTurnChanged(_playerTurn.CurrentPlayer);
    }

    private void OnTurnChanged(IPlayer obj)
    {
        _text.text = "Current player name is " + obj.Config.Name;
        _text.color = obj.Config.Color;
    }
}
