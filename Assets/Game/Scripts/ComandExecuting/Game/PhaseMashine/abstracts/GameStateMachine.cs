using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameStates
{
    public abstract class GameStateMachine : GameState, IStateParent
    {
        private IGameState _currentState;
        private readonly List<IGameState> _states;

        public GameStateMachine(List<IGameState> states) 
        {
            _states = states;
        }

        public override sealed void Initialize(IStateParent parent)
        {
            Parent = parent;
            foreach (var state in _states)
                state.Initialize(this);
        }

        void IStateParent.SwitchToState<TState>() 
        {
            _currentState?.Stop();
            _currentState = (TState)_states.First(x => x is TState);
            _currentState.Start();
        }

        public override sealed void ExecuteCommand(IGameCommand command) => _currentState.ExecuteCommand(command);

        protected override sealed void ApplyActionsList() => DoNothing();        
    }
}