using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCommandsGate : IGameCommandClient, IGameCommandGate, ICommandsBlocker
{
    public event Action<IGameCommand> CommandReceived;
    public event Action BecomeLocked;

    public bool Locked { get; private set; }



    public void Receive(IGameCommand action)
    {
        if (Locked)
            return;

        CommandReceived?.Invoke(action);
    }

    void ICommandsBlocker.Lock()
    {
        if (Locked)
            throw new Exception("Gate already locked");

        BecomeLocked?.Invoke();
        Locked = true;
    }

    void ICommandsBlocker.Unlock()
    {
        if (Locked == false)
            throw new Exception("Gate already unlocked");

        Locked = false;
    }
}
