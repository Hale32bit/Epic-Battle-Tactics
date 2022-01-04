using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public sealed class PlayerInstallerBox : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Color _color;

    public void Install(DiContainer subcontainer)
    {
        subcontainer.BindInterfacesAndSelfTo<HotSeatPlayer>()
            .FromNew()
            .AsSingle();

        subcontainer.Bind<PlayerConfig>()
            .FromNew()
            .AsSingle()
            .WithArguments(_name, _color);
    }
}
