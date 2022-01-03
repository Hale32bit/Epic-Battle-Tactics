using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AvaliableActions;
using Zenject;

namespace GameStates
{
    namespace Phase1Space
    {
        public sealed class PlaceTokenSubphase : TrueGameState<PlaceTokenActionsList>
        {
            private CellPanel _cellPanel;
            private CellPanelConfig _panelConfig;
            private ITokenPlacer _placer;

            public PlaceTokenSubphase(
                IAvaliableActionsClient actionsClient,
                CellPanel cellPanel,
                ITokenPlacer placer,
                [Inject(Id = CellPanelConfigType.Place)] CellPanelConfig panelConfig) 
                : base(actionsClient)
            {
                _cellPanel = cellPanel;
                _panelConfig = panelConfig;
                _placer = placer; 
            }

            public override void ExecuteCommand(IGameCommand command)
            {
                if (command.Category == CommandCategory.Targeting)
                    _cellPanel.SetDestination(command.Container as BattlefieldCell);
                if (command.Category == CommandCategory.Accept)
                    PlaceToken();
            }

            private void PlaceToken()
            {
                _placer.Place(_cellPanel.Destination);
                Parent.SwitchToState<RotateTokenSubphase>();
            }

            protected override void OnStarted()
            {
                _cellPanel.SetConfig(_panelConfig);
            }

            protected override void OnStoped() => DoNothing();
        
        }
    }
}