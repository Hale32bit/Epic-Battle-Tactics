using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

[DisallowMultipleComponent]
public class TokensSpawner : ITokenSpawner
{
    private Token.Factory _factory;
    private ISpawnedTokenContainer _spawnedTokenContainer;

    [Inject]
    private TokensSpawner(
        Token.Factory factory, 
        ISpawnedTokenContainer spawnedTokenContainer)
    {
        _factory = factory;
        _spawnedTokenContainer = spawnedTokenContainer;
    }

    public ISpawnedTokenContainer Spawn()
    {
        var token = _factory.Create();
        token.transform.SetPositionAndRotation(_spawnedTokenContainer.Transform.position, _spawnedTokenContainer.Transform.rotation);
        _spawnedTokenContainer.Attach(token);
        return _spawnedTokenContainer;
    }
}
