namespace GameStates
{
    public interface IStateSwitcher
    {
        void SwitchToState<TState>() where TState : GameState;    
    }
}