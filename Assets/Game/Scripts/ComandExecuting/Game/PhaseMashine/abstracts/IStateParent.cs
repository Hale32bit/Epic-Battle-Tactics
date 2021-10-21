namespace GameStates
{
    public interface IStateParent : IAvaliableActionsClient
    {
        void SwitchToState<TState>() where TState : GameState;    
    }
}