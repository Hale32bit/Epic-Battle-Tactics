using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameStates;
using AvaliableActions;

namespace GameStates
{
namespace Phase1Space
{
        public sealed class RotateTokenSubphase : TrueGameState<RotateTokenActionsList>
        {
            private CellPanel _cellPanel;
           // private ISelector _selector;


            public RotateTokenSubphase(
                IAvaliableActionsClient actionsClient,
                CellPanel cellPanel,
                ISelector selector) 
                : base(actionsClient)
            {
                _cellPanel = cellPanel;
              //  _selector = selector;
            }

            public override void ExecuteCommand(IGameCommand command)
            {

            }

            protected override void OnStarted() => DoNothing();

            protected override void OnStoped() => DoNothing();

        }
    }
}