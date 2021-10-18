using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Zenject;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(TokensSpawner))]
public class TokenPresentationMoving : MonoBehaviour
{

    private void OnEnable()
    {
        var spawner = GetComponent<TokensSpawner>();
        spawner.Spawned += OnSpawned;
    }
    private void OnDisable()
    {
        var spawner = GetComponent<TokensSpawner>();
        spawner.Spawned -= OnSpawned;
    }

    private void OnSpawned(Token obj)
    {
        obj.transform.DOMove(Vector3.up * 5, 3f);
    }
}
