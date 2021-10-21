using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStates
{
public sealed class PhaseMaschine : GameStateMachine
{
        public PhaseMaschine(IStateParent switcher) : base(switcher)
        {
            _states = new GameStates.GameState[1]
                { 
                    new GameStates.Phase1(this) 
                };           
        }

        protected override void OnStarted() 
        {
            (this as IStateParent).SwitchToState<Phase1>();
        }


        protected override void OnStoped()=> DoNothing();

    }
}
