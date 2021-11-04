using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AvaliableActions;

namespace GameStates
{
    namespace Phase1Space
    {
        public sealed class TakeTokenSubphase : TrueGameState<TakeTokenActionsList>
        {
            private INewTokenTaker _taker;

            public TakeTokenSubphase(
                IAvaliableActionsClient actionsClient,
                INewTokenTaker taker)
            : base(actionsClient)
            {
                _taker = taker;
            }

            public override void ExecuteCommand(IGameCommand command)
            {
                if (command.Category == CommandCategory.Take)
                    TakeToken();
            }

            private void TakeToken()
            {
                _taker.Take();
                Parent.SwitchToState<PlaceTokenSubphase>();
            }

            protected override void OnStarted() => DoNothing();

            protected override void OnStoped() => DoNothing();

        }
    }
}