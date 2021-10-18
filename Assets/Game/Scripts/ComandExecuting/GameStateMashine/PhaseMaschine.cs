using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStates
{
public sealed class PhaseMaschine : GameStates.GameStateMachine
{
        public PhaseMaschine(IStateSwitcher switcher) : base(switcher)
        {
            _states = new GameStates.GameState[1]
                { new Phase1(this) };

            this.Started += (this as IStateSwitcher).SwitchToState<Phase1>;
        }

    
}
}
