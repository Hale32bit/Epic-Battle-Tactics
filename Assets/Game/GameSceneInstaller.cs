using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

[DisallowMultipleComponent]
public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private Camera _camera;
    [SerializeField] private PlayerInput _playerInputPrefab;
    [SerializeField] private Token _tokenPrefab;
    [SerializeField] private Battlefield _battlefieldPrefab;

    public override void InstallBindings()
    {
        BindCamera();

        BindInputActions();

        BindBattlefield();

        BindTokenFactory();

        BindPlayer();

        BindActionsGate();
    }

    private void BindActionsGate()
    {
        Container.BindInterfacesTo<GameCommandsGate>()
            .FromNew()
            .AsSingle();
    }

    private void BindPlayer()
    {
        Container.Bind<IAvaliableActionsClient>()
            .To<HotSeatPlayer>()
            .FromNew()
            .AsSingle();
    }

    private void BindTokenFactory()
    {
        Container.BindFactory<Token, Token.Factory>()
            .FromComponentInNewPrefab(_tokenPrefab);
    }

    private void BindCamera()
    {
        Container.Bind<Camera>()
            .FromInstance(_camera)
            .AsSingle();
    }

    private void BindInputActions()
    {
        Container.Bind<InputActions>().AsSingle();
    }

    private void BindBattlefield()
    {
        Container.Bind<Battlefield>()
            .FromComponentInNewPrefab(_battlefieldPrefab)
            .AsSingle();
    }
}
