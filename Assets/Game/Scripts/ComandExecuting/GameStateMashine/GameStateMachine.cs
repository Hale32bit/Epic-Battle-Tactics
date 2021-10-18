using System.Linq;

namespace GameStates
{
    public abstract class GameStateMachine : GameState, IStateSwitcher
    {
        private GameState _currentState;
        protected GameState[] _states;

        public GameStateMachine(IStateSwitcher switcher) : base(switcher)
        {
        }

        void IStateSwitcher.SwitchToState<TState>() 
        {
            _currentState?.Stop();
            _currentState = (TState)_states.First(x => x is TState);
            _currentState.Start();
        }

        public override sealed void ExecuteCommand(IGameCommand command) => _currentState.ExecuteCommand(command);
        

    }
}