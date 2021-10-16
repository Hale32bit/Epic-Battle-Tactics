using System;

public interface IGameCommandGate
{
    event Action<IGameCommand> CommandReceived;
    event Action BecomeLocked;
}
