using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using Zenject;

[DisallowMultipleComponent]
public abstract class Player : IAvaliableActionsClient
{  
    protected AvaliableActionsList AvaliableActions;

    protected IGameCommandClient Client;

    [Inject]
    private void Construct(IGameCommandClient gameCommandClient)
    {
        Client = gameCommandClient;
    }

    public void Receive(AvaliableActionsList actions)
    {
        AvaliableActions = actions;
    }
}

