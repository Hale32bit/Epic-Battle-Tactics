using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using GameStates;

public sealed class Game : CommandExecutor, IGameStatesProvider, IStateParent
{
    private IAvaliableActionsClient _client;

    private PhaseMaschine _phases;

    [Inject]
    private void Construct(IAvaliableActionsClient client)
    {
        _client = client;
        _phases = new PhaseMaschine(this);
    }

    void Start()
    {
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

    public IGameStatePublisher GetGameState<TState>() where TState : IGameStatePublisher
    {
        return _phases.States().First(state => state is TState);
    }

    void IStateParent.SwitchToState<TState>()
    {
        throw new NotImplementedException();
    }

    void IAvaliableActionsClient.Receive(AvaliableActionsList actions)
    {
        _client.Receive(actions);
    }
}
