using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameStates;

namespace GameStates
{
namespace Phase1Space
{
        public sealed class RotateTokenSubphase : GameStates.GameState
        {
            public RotateTokenSubphase(IStateSwitcher switcher) : base(switcher)
            {
            }

            public override void ExecuteCommand(IGameCommand command)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}