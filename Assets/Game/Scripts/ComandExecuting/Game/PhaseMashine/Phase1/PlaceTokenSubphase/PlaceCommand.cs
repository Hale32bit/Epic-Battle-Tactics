using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStates.Phase1Space
{
    public class PlaceCommand : GameCommand
    {
        public PlaceCommand()
        {
            Category = CommandCategory.Targeting;
        }
    }
}