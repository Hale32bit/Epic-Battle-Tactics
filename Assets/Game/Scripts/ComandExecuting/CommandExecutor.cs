using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class CommandExecutor : MonoBehaviour
{

    [Inject]
    private void Construct(IGameCommandGate gate)
    {
        gate.CommandReceived += OnCommand;
        gate.BecomeLocked += OnGateLocked;
    }

    protected abstract void OnGateLocked();

    protected abstract void OnCommand(IGameCommand command);
}
