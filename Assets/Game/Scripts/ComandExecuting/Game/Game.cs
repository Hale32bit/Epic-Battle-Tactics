using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using GameStates;

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

    private AvaliableActionsList GenerateSimpleActionList()
    {
        return new AvaliableActions.DefaultActionList();
    }

    protected override void OnGateLocked()
    { }

    protected override void OnCommand(IGameCommand command)
    {
        _phases.ExecuteCommand(command);

        Debug.Log(command.Category.ToString());
    }


    void IStateParent.SwitchToState<TState>()
    {
        throw new NotImplementedException();
    }
}
