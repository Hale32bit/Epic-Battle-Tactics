namespace GameStates
{
    public interface IStateParent
    {
        void SwitchToState<TState>() where TState : GameState;    
    }
}