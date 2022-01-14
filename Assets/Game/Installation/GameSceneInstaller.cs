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
    [SerializeField] private Battlefield _battlefieldPrefab;
    [SerializeField] private PreCameraTokenButton _preCameraTokenPanel;
    [SerializeField] private CellPanel _cellPanel;
    [SerializeField] private TokensSpawnPoint _tokensSpawnPoint;

    [SerializeField] private GameObject _cameraRotationCenter;
    [SerializeField] private TokenPresentationPanel _presentationPanelInstanse;

    [SerializeField] private CellPanelConfig _placeCellPanelConfig;
    [SerializeField] private CellPanelConfig _rotateCellPanelConfig;


    [SerializeField] private PlayerInstallerBox _firstPlayerInstaller;
    [SerializeField] private PlayerInstallerBox _SecondPlayerInstaller;

    public override void InstallBindings()
    {
        BindCamera();

        BindInputActions();

        BindBattlefield();

        BindPlayers();

        BindActionsGate();

        BindCommandExecutors();

        BindUI();

        Container.BindInterfacesAndSelfTo<TokensSpawnPoint>()
                    .FromInstance(_tokensSpawnPoint)
                    .AsSingle();

        Container.BindInterfacesAndSelfTo<TokenPresentationPanel>()
            .FromInstance(_presentationPanelInstanse)
            .AsSingle();

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

        Container.BindInterfacesAndSelfTo<WorldPointerInput>()
            .FromNew()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<WorldPointerHandler_new>()
            .FromNew()
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

        Container.BindInterfacesAndSelfTo<ReturnerToPrecamera>()
            .FromNew()
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

        Container.BindInterfacesAndSelfTo<CellPanel>()
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

    private void BindPlayers()
    {
        var subcontainer1 = Container.CreateSubContainer();
        var subcontainer2 = Container.CreateSubContainer();

        _firstPlayerInstaller.Install(subcontainer1);
        _SecondPlayerInstaller.Install(subcontainer2);

        Container.Bind<IPlayer>()
            .WithId("first")
            .To<HotSeatPlayer>()
            .FromSubContainerResolve()
            .ByInstance(subcontainer1)
            .AsCached();

        Container.Bind<IPlayer>()
            .WithId("second")
            .To<HotSeatPlayer>()
            .FromSubContainerResolve()
            .ByInstance(subcontainer2)
            .AsCached();

        Container.BindInterfacesAndSelfTo<PlayerTurn>()
            .FromNew()
            .AsSingle();
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
