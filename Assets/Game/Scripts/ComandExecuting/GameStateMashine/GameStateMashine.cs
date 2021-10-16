using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStateMashine : MonoBehaviour
{
    private IAvaliableActionsClient _client;

    [Inject]
    private void Construct(IAvaliableActionsClient client, IGameCommandGate gate)
    {
        _client = client;
        gate.CommandReceived += OnActionReceived;
    }

    private void OnActionReceived(IGameCommand action)
    {
        Debug.Log(action.Category.ToString());
    }

    void Start()
    {
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


}
