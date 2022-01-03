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

            public RotateTokenSubphase(
                IAvaliableActionsClient actionsClient,
                CellPanel cellPanel,
                [Inject(Id = CellPanelConfigType.Rotate)] CellPanelConfig panelConfig) 
                : base(actionsClient)
            {
                _cellPanel = cellPanel;
                _panelConfig = panelConfig;
            }

            public override void ExecuteCommand(IGameCommand command)
            {
            }

            protected override void OnStarted()
            {
                Debug.Log("new config");
                _cellPanel.SetConfig(_panelConfig);
            }

            protected override void OnStoped() => DoNothing();

        }
    }
}