using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameStates
{
    public abstract class GameStateMachine : GameState, IStateParent
    {
        private GameState _currentState;
        protected GameState[] _states;

        public GameStateMachine(IStateParent switcher) : base(switcher)
        {
        }

        void IStateParent.SwitchToState<TState>() 
        {
            _currentState?.Stop();
            _currentState = (TState)_states.First(x => x is TState);
            _currentState.Start();
        }

        public override sealed void ExecuteCommand(IGameCommand command) => _currentState.ExecuteCommand(command);

        void IAvaliableActionsClient.Receive(AvaliableActionsList actions)
        {
            this.Parent.Receive(actions);
        }

        public override IEnumerable<IGameStatePublisher> States()
        {
            IEnumerable<IGameStatePublisher> enumerable = _states;
            foreach (var state in _states)
                enumerable = enumerable.Concat(state.States());
            return enumerable;
        }

        protected override sealed void ApplyActionsList() => DoNothing();        
    }
}