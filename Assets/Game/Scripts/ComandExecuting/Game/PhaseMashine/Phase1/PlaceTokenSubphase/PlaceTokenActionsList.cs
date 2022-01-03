using AvaliableActions;
using DG.Tweening.Core.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameStates.Phase1Space
{
    public class PlaceTokenActionsList : AvaliableActionsList
    {
        public PlaceTokenActionsList()
        {
            Avaliables = new AvaliableAction[]
            {
                new HighlightON(),
                new HighlightOFF(),
                new PlaceAction(),
                new CellAcceptAction()
            };
        }
    }
}