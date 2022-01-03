using AvaliableActions;
using DG.Tweening.Core.Enums;
using GameCommands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStates.Phase1Space
{
    public class RotateTokenActionsList : AvaliableActionsList
    {
        public RotateTokenActionsList()
        {
            Avaliables = new AvaliableAction[]
            {
                new CellAcceptAction(),
                new CellCancelAction(),
                new CellClockwiseRotateAction(),
                new CellCounterclockwiseRotateAction()
            };
        }
    }
}