using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

[DisallowMultipleComponent]
public class TokensSpawner : MonoBehaviour
{
    public event Action<Token> Spawned;

    private InputAction _spawnAction;
    private Token.Factory _factory;

    [Inject]
    private void Construct(InputActions input, Token.Factory factory)
    {
        _factory = factory;
        _spawnAction = input.Player.SpawnToken;
    }

    private void OnEnable()
    {
        _spawnAction.performed += OnSpawnAction;
        _spawnAction.Enable();
    }

    private void OnDisable()
    {
        _spawnAction.performed -= OnSpawnAction;
        _spawnAction.Disable();
    }

    private void OnSpawnAction(InputAction.CallbackContext obj)
    {
        var token = _factory.Create();
        token.transform.SetPositionAndRotation(this.transform.position, Quaternion.identity);
        Spawned?.Invoke(token);
    }
}
