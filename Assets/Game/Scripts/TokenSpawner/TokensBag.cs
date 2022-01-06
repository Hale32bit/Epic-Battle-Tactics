using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public sealed class TokensBag : ITokensBag
{
    public int Count => _content.Count;

    private LinkedList<string> _content = new LinkedList<string>();
    private DiContainer _diContainer;

    public TokensBag(
        TokensBagInstallerBox.TokensBagEntry[] data,
        DiContainer diContainer)
    {
        _diContainer = diContainer;
        _content = TransformToContent(data);
    }

    private LinkedList<string> TransformToContent(TokensBagInstallerBox.TokensBagEntry[] data)
    {
        LinkedList<string> content = new LinkedList<string>();
        foreach (var entry in data)
            for (int i = 0; i < entry.Count; i++)
                content.AddFirst(entry.TokenID);
        return content;
    }

    public void Shuffle()
    {
        LinkedList<string> shufledContent = new LinkedList<string>();
        int contentSize = _content.Count;
        for (int i = 0; i < contentSize; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, _content.Count);
            Debug.Log(_content.Count);
            shufledContent.AddFirst(_content.ElementAt(randomIndex));
            _content.Remove(shufledContent.First.Value);
        }
        _content = shufledContent;
    }

    public Token GetToken()
    {
        string id = _content.First();
        _content.RemoveFirst();
        return _diContainer.ResolveId<Token>(id);
    }
}
