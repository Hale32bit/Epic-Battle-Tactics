using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStates
{
namespace Phase1Space
{

public sealed class TakeTokenSubphase : GameStates.GameState
{
            public TakeTokenSubphase(IStateSwitcher switcher) : base(switcher) 
            {
                this.Started += TakeToken;
            }

            private void TakeToken()
            {
                throw new NotImplementedException();
                
            }

            public override void ExecuteCommand(IGameCommand command)
            {
                throw new System.NotImplementedException();
            }

}
}
}