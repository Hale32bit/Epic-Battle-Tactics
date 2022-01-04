using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using Zenject;

[DisallowMultipleComponent]
public abstract class Player :  IPlayer
{  
    public PlayerConfig Config { get; private set; }
    public bool Active { get; private set; }
    protected AvaliableActionsList AvaliableActions;
    protected IGameCommandClient Client;

    protected Player(IGameCommandClient client, PlayerConfig config)
    {
        Client = client;
        Config = config;
    }

    public void Receive(AvaliableActionsList actions)
    {
        AvaliableActions = actions;
    }

    public void SetActive(bool value)
    {
        Active = value;
    }
}

