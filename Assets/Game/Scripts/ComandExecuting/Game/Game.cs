using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using GameStates;

[NeedsGamePhase(typeof(PhaseMaschine))]
public sealed class Game : CommandExecutor, IStateParent
{
    private IGameState _phases;

    [Inject]
    private void Construct(IGameState phaseMashine)
    {
        _phases = phaseMashine;
    }

    void Start()
    {
        _phases.Initialize(this);
        _phases.Start();
    }

    protected override void OnGateLocked()
    { }

    protected override void OnCommand(IGameCommand command)
    {
        _phases.ExecuteCommand(command);
    }

    void IStateParent.SwitchToState<TState>()
    {
        throw new NotImplementedException();
    }
}
