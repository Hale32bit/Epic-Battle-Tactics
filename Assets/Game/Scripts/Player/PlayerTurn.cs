using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerTurn : IAvaliableActionsClient
{
    public event Action<IPlayer> TurnChanged;

    public IPlayer CurrentPlayer { get; private set; }

    private readonly IPlayer PlayerOne;
    private readonly IPlayer PlayerTwo;

    public PlayerTurn(
        [Inject(Id ="first")] IPlayer playerOne,
        [Inject(Id = "second")] IPlayer playerTwo)
    {
        PlayerOne = playerOne;
        PlayerTwo = playerTwo;
        CurrentPlayer = PlayerOne;
        CurrentPlayer.SetActive(true);
    }

    public void NextTurn()
    {
        CurrentPlayer.SetActive(false);
        if (CurrentPlayer == PlayerOne)
            CurrentPlayer = PlayerTwo;
        else
            CurrentPlayer = PlayerOne;
        CurrentPlayer.SetActive(true);
        TurnChanged?.Invoke(CurrentPlayer);
    }

    public void Receive(AvaliableActionsList actions)
    {
        CurrentPlayer.Receive(actions);
    }
}
