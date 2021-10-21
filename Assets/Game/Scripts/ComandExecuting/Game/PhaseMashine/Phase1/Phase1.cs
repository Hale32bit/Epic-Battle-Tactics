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
        public Phase1(IStateParent switcher) : base(switcher)
        {
            _states = new GameState[3] 
            {
                new TakeTokenSubphase(this),
                new PlaceTokenSubphase(this),
                new RotateTokenSubphase(this)
            };
        }

        protected override void OnStarted()
        {
            (this as IStateParent).SwitchToState<TakeTokenSubphase>();
        }

        protected override void OnStoped() => DoNothing();
        
    }
}