using System;

internal interface IPlayerTurn
{
    IPlayer CurrentPlayer { get; }

    event Action<IPlayer> TurnChanged;
}