using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public sealed class GamePhaseMashine : CommandExecutor
{
    private IAvaliableActionsClient _client;

    private GameStates.PhaseMaschine _phases;

    [Inject]
    private void Construct(IAvaliableActionsClient client)
    {
        _client = client;
    }

    void Start()
    {
        _phases = new GameStates.PhaseMaschine(null);
        _phases.Start();


        AvaliableActionsList actionsList = GenerateSimpleActionList();

        _client.Receive(actionsList);
    }

    private AvaliableActionsList GenerateSimpleActionList()
    {
        var avaliables = new AvaliableAction[]
            { 
            new AvaliableActions.SpawnOnBattlefield(),
            new AvaliableActions.HighlightON(),
            new AvaliableActions.HighlightOFF()
            };
        var actionsList = new AvaliableActionsList(avaliables);
        return actionsList;
    }

    protected override void OnGateLocked()
    { }

    protected override void OnCommand(IGameCommand command)
    {
        _phases.ExecuteCommand(command);

        Debug.Log(command.Category.ToString());
    }
}
