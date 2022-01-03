using System.Net;
using System.ComponentModel;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

[DisallowMultipleComponent]
public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CameraRotation _cameraRotaion;
    [SerializeField] private PlayerInput _playerInputPrefab;
    [SerializeField] private Token _tokenPrefab;
    [SerializeField] private Battlefield _battlefieldPrefab;
    [SerializeField] private PreCameraTokenButton _preCameraTokenPanel;
    [SerializeField] private CellPanel _cellPanel;

    [SerializeField] private GameObject _tokensSpawner;
    [SerializeField] private GameObject _cameraRotationCenter;

    [SerializeField] private CellPanelConfig _placeCellPanelConfig;
    [SerializeField] private CellPanelConfig _rotateCellPanelConfig;

    [SerializeField] private TokenRotator _tokenRotator;

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

        BindTokenMovers();

        Container.Bind<CellPanelConfig>()
            .WithId(CellPanelConfigType.Place)
            .FromInstance(_placeCellPanelConfig)
            .AsCached();

        Container.Bind<CellPanelConfig>()
            .WithId(CellPanelConfigType.Rotate)
            .FromInstance(_rotateCellPanelConfig)
            .AsCached();


        Container.Bind<CameraRotationModel>()
            .FromComponentOn(_cameraRotationCenter)
            .AsSingle();

        Container.Bind<CameraRotation>()
            .FromInstance(_cameraRotaion)
            .AsSingle();
    }

    private void BindTokenMovers()
    {
        Container.BindInterfacesAndSelfTo<NewTokenTaker>()
            .FromNew()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<TokenPlacer>()
            .FromNew()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<TokenRotator>()
            .FromInstance(_tokenRotator)
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
            .FromInstance(_preCameraTokenPanel)
            .AsSingle();

        Container.Bind<CellPanel>()
            .FromInstance(_cellPanel)
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
