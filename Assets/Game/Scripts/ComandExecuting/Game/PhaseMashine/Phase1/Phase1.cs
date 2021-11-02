using System.Globalization;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameStates.Phase1Space;

namespace GameStates
{

public sealed class Phase1 : GameStates.GameStateMachine
{
        public Phase1(List<IGameState> states) : base(states)
        {
        }

        protected override void OnStarted()
        {
            (this as IStateParent).SwitchToState<TakeTokenSubphase>();
        }

        protected override void OnStoped() => DoNothing();
        
    }
}