using System.Net;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using GameStates;
using GameStates.Phase1Space;

[DisallowMultipleComponent]
public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private Camera _camera;
    [SerializeField] private PlayerInput _playerInputPrefab;
    [SerializeField] private Token _tokenPrefab;
    [SerializeField] private Battlefield _battlefieldPrefab;
    [SerializeField] private PreCameraTokenButton _preCameraTokenPanel;

    [SerializeField] private GameObject _tokensSpawner;
    

    public override void InstallBindings()
    {
        BindCamera();

        BindInputActions();

        BindBattlefield();

        BindPlayer();

        BindActionsGate();

        BindCommandExecutors();

        BindUI();

        BindTokenSpawner();

        GamePhasesInstaller.Install(Container);

        Container.BindInterfacesAndSelfTo<NewTokenTaker>()
            .FromNew()
            .AsSingle();
    }

    private void BindTokenSpawner()
    {
        BindSpawnedTokenContainer();

        BindTokenFactory();

        Container.BindInterfacesAndSelfTo<TokensSpawner>()
    .FromComponentOn(_tokensSpawner)
    .AsSingle();
    }

    private void BindSpawnedTokenContainer()
    {
        Container.BindInterfacesAndSelfTo<SpawnedTokenContainer>()
                    .FromNewComponentOnNewGameObject()
                    .AsSingle();
    }

    private void BindUI()
    {
        Container.Bind<UIEventRoot>()
            .FromNewComponentOnNewGameObject()
            .AsSingle();

        Container.Bind<PreCameraTokenButton>()
            .FromComponentsOn(_preCameraTokenPanel.gameObject)
            .AsSingle();

        Container.BindInterfacesAndSelfTo<PreCameraTokenContainer>()
            .FromComponentsOn(_preCameraTokenPanel.gameObject)
            .AsSingle();
    }

    private void BindCommandExecutors()
    {
        BindSelector();
    }

    private void BindSelector()
    {
        Container.BindInterfacesTo<Selector>()
            .FromNewComponentOnNewGameObject()
            .AsSingle();
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

internal class GamePhasesInstaller : Installer<GamePhasesInstaller>
{
    public override void InstallBindings()
    {
        BindPhaseMashine();
    }

    private void BindPhaseMashine()
    {
        Container.BindInterfacesTo<PhaseMaschine>()
            .AsSingle()
            .WhenInjectedInto(typeof(Game));

        BindPhase1();
    }

    private void BindPhase1()
    {
        Container.BindInterfacesTo<Phase1>()
            .AsSingle()
            .WhenInjectedInto(typeof(PhaseMaschine));

        Container.BindInterfacesTo<RotateTokenSubphase>()
            .AsSingle()
            .WhenInjectedInto(typeof(Phase1));

        Container.BindInterfacesTo<TakeTokenSubphase>()
            .AsSingle()
            .WhenInjectedInto(
            typeof(Phase1),
            typeof(PreCameraTokenPanelEnabler));



        Container.BindInterfacesTo<PlaceTokenSubphase>()
            .AsSingle()
            .WhenInjectedInto(typeof(Phase1));
    }
}