using Zenject;
using GameStates;
using GameStates.Phase1Space;

internal class GamePhasesInstaller : Installer<GamePhasesInstaller>
{
    public override void InstallBindings()
    {
        BindPhaseMashine();
    }

    private void BindPhaseMashine()
    {
        BindPhase<PhaseMaschine>();

        BindPhase1();
    }

    private void BindPhase1()
    {
        BindPhase<Phase1>();

        BindPhase<RotateTokenSubphase>();

        BindPhase<TakeTokenSubphase>();

        BindPhase<PlaceTokenSubphase>();
    }

    private void BindPhase<TPhase>()
    {
        Container.BindInterfacesTo<TPhase>()
            .AsSingle()
            .WhenInjectedInto(TypeExtensions.AllTypesNeeds<TPhase>());
    }
}
