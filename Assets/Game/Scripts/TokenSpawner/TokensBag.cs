using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public sealed class TokensBag : IInitializable
{
    [Serializable]
    public sealed class TokensBagEntry
    {
        [SerializeField] private string _tokenID;
        public string TokenID => _tokenID;
        
        [SerializeField] private int _count;

        public int Count => _count;

        public void Decrement()
        {
            _count--;
        }
    }

    private List<TokensBagEntry> _content;
    private DiContainer _diContainer;

    public TokensBag(
        List<TokensBagEntry> content,
        DiContainer diContainer)
    {
        _content = content;
        _diContainer = diContainer;
    }

    void IInitializable.Initialize()
    {
    }

    public Token GetToken()
    {
        string id = _content[UnityEngine.Random.Range(0, _content.Count)].TokenID;
        return _diContainer.ResolveId<Token>(id);
    }
}
