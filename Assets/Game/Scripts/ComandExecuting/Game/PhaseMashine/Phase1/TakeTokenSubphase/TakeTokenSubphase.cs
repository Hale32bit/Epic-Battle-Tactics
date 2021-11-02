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
            private ITokenMover _tokenMover;
            private ITokenSpawner _tokensSpawner;
            private IPreCameraTokenContainer _preCamera;

                public TakeTokenSubphase(
                    IAvaliableActionsClient actionsClient, 
                    ITokenMover tokenMover, 
                    ITokenSpawner tokensSpawner,
                    IPreCameraTokenContainer preCamera) 
                : base(actionsClient)
            {
                _tokenMover = tokenMover;
                _tokensSpawner = tokensSpawner;
                _preCamera = preCamera;
            }

            public override void ExecuteCommand(IGameCommand command)
            {
                if(command.Category ==  CommandCategory.Take)
                    TakeToken();
            }

            private void TakeToken()
            {
                var initial = _tokensSpawner.Spawn();
                _tokenMover.MoveToken(initial, _preCamera);

                Parent.SwitchToState<PlaceTokenSubphase>();
            }

            protected override void OnStarted() => DoNothing();

            protected override void OnStoped() => DoNothing();

}
}
}