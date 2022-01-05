using System;

public interface IPlayerTurn
{
    IPlayer CurrentPlayer { get; }

    event Action<IPlayer> TurnChanged;
}