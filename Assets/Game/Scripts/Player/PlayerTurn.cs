using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : IAvaliableActionsClient
{
    public Player CurrentPlayer { get; private set; }

    private readonly Player PlayerOne;
    private readonly Player PlayerTwo;

    public PlayerTurn(Player playerOne, Player playerTwo)
    {
        PlayerOne = playerOne;
        PlayerTwo = playerTwo;
        CurrentPlayer = PlayerOne;
    }

    public void NextTurn()
    {
        if (CurrentPlayer == PlayerOne)
            CurrentPlayer = PlayerTwo;
        else
            CurrentPlayer = PlayerOne;
    }

    public void Receive(AvaliableActionsList actions)
    {
        CurrentPlayer.Receive(actions);
    }
}
