using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[DisallowMultipleComponent]
public sealed class TokensInstallerBox : MonoBehaviour
{
    [Serializable]
    public class TokenPrefabIDData
    {
        [SerializeField] private Token _tokenPrefab;
        public Token TokenPrefab => _tokenPrefab;
        [SerializeField] private string _ID;
        public string ID => _ID;
    }

    [SerializeField] TokenPrefabIDData[] _prefabs;

    public void Install(DiContainer subcontainer)
    {
        foreach (var entry in _prefabs)
        {
            subcontainer.Bind<Token>()
                .WithId(entry.ID)
                .FromComponentInNewPrefab(entry.TokenPrefab)
                .AsTransient();
        }
    }
}
