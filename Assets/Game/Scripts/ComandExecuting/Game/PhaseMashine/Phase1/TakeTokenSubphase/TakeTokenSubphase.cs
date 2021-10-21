using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AvaliableActions;

namespace GameStates
{
namespace Phase1Space
{
public sealed class TakeTokenSubphase : TrueGameState<DefaultActionList>
        {
            public TakeTokenSubphase(IStateParent switcher) : base(switcher) 
            { }

            public override void ExecuteCommand(IGameCommand command)
            {
                
            }

            protected override void OnStarted() => DoNothing();

            protected override void OnStoped() => DoNothing();

}
}
}