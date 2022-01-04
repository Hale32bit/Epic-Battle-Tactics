using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameStates;
using AvaliableActions;
using Zenject;

namespace GameStates
{
namespace Phase1Space
{
        public sealed class RotateTokenSubphase : TrueGameState<RotateTokenActionsList>
        {
            private CellPanel _cellPanel;
            private CellPanelConfig _panelConfig;
            private IReturnerToPrecamera _returner;

            public RotateTokenSubphase(
                IAvaliableActionsClient actionsClient,
                CellPanel cellPanel,
                [Inject(Id = CellPanelConfigType.Rotate)] CellPanelConfig panelConfig,
                IReturnerToPrecamera returner) 
                : base(actionsClient)
            {
                _cellPanel = cellPanel;
                _panelConfig = panelConfig;
                _returner = returner;
            }

            public override void ExecuteCommand(IGameCommand command)
            {
                if (command.Category == CommandCategory.ClockwiseRotate)
                {
                    var token = _cellPanel.Destination.GetToken();
                    token.SetRotationStep(token.RotationStep + 1);
                }
                if (command.Category == CommandCategory.CounterClockwiseRotate)
                {
                    var token = _cellPanel.Destination.GetToken();
                    token.SetRotationStep(token.RotationStep - 1);
                }
                if (command.Category == CommandCategory.Cancel)
                {
                    _cellPanel.Destination.GetToken().SetRotationStep(0);
                    _returner.Return();
                    Parent.SwitchToState<PlaceTokenSubphase>();
                }
            }

            protected override void OnStarted()
            {
                Debug.Log("new config");
                _cellPanel.SetConfig(_panelConfig);
            }

            protected override void OnStoped()
            {
                _cellPanel.SetUnvisible();
            }


        }
    }
}