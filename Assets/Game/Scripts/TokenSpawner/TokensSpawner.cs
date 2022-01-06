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
    private TokensBag _bag;
    private ISpawnedTokenContainer _spawnedTokenContainer;

    [Inject]
    private TokensSpawner(
        TokensBag bag, 
        ISpawnedTokenContainer spawnedTokenContainer)
    {
        _bag = bag;
        _spawnedTokenContainer = spawnedTokenContainer;
        _bag.Shuffle();
    }

    public ISpawnedTokenContainer Spawn()
    {
        var token = _bag.GetToken();
        token.transform.SetPositionAndRotation(_spawnedTokenContainer.Transform.position, _spawnedTokenContainer.Transform.rotation);
        _spawnedTokenContainer.Attach(token);
        return _spawnedTokenContainer;
    }
}
