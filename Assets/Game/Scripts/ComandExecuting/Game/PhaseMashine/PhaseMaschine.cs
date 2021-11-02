using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStates
{
public sealed class PhaseMaschine : GameStateMachine
{
        public PhaseMaschine(List<IGameState> states) : base(states)
        {
        }

        protected override void OnStarted() 
        {
            (this as IStateParent).SwitchToState<Phase1>();
        }


        protected override void OnStoped()=> DoNothing();

    }
}
