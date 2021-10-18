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
        public Phase1(IStateSwitcher switcher) : base(switcher)
        {
            _states = new GameState[3] 
            {
                new PlaceTokenSubphase(this),
                new TakeTokenSubphase(this),
                null
            };

            this.Started += (this as IStateSwitcher).SwitchToState<TakeTokenSubphase>;
        }
}
}