using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameStates;
using AvaliableActions;

namespace GameStates
{
namespace Phase1Space
{
        public sealed class RotateTokenSubphase : TrueGameState<DefaultActionList>
        {
            public RotateTokenSubphase(IAvaliableActionsClient actionsClient) : base(actionsClient)
            {
            }

            public override void ExecuteCommand(IGameCommand command)
            {
                throw new System.NotImplementedException();
            }

            protected override void OnStarted() => DoNothing();

            protected override void OnStoped() => DoNothing();

        }
    }
}