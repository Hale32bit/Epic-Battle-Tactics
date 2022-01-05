using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public sealed class PlayerInstallerBox : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Color _color;
    [SerializeField] private Token _tokenPrefab;
    [SerializeField] private TokensInstallerBox _tokensInstallerBox;

    public void Install(DiContainer subcontainer)
    {
        _tokensInstallerBox.Install(subcontainer);

        subcontainer.BindFactory<Token, Token.Factory>()
            .FromComponentInNewPrefab(_tokenPrefab);

        subcontainer.BindInterfacesAndSelfTo<TokensSpawner>()
            .FromNew()
            .AsSingle();

        subcontainer.BindInterfacesAndSelfTo<HotSeatPlayer>()
            .FromNew()
            .AsSingle();

        subcontainer.Bind<PlayerConfig>()
            .FromNew()
            .AsSingle()
            .WithArguments(_name, _color);
    }
}
