using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public sealed class TokensBagInstallerBox : MonoBehaviour
{
    [Serializable]
    public sealed class TokensBagEntry
    {
        [SerializeField] private string _tokenID;
        public string TokenID => _tokenID;
        [SerializeField] private int _count;
        public int Count => _count;
    }

    [SerializeField] private TokensBagEntry[] _content;

    public void Install(DiContainer subcontainer)
    {
        subcontainer.BindInterfacesAndSelfTo<TokensBag>()
            .FromNew()
            .AsSingle()
            .WithArguments(_content, subcontainer);
    }
}
