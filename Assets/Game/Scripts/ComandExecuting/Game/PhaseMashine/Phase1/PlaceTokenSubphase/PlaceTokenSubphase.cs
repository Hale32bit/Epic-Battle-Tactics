using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AvaliableActions;

namespace GameStates
{
    namespace Phase1Space
    {
        public sealed class PlaceTokenSubphase : TrueGameState<DefaultActionList>
        {
            public PlaceTokenSubphase(IAvaliableActionsClient actionsClient) : base(actionsClient)
            {
            }

            public override void ExecuteCommand(IGameCommand command)
            {

            }

            protected override void OnStarted() => DoNothing();

            protected override void OnStoped() => DoNothing();
        }
    }
}