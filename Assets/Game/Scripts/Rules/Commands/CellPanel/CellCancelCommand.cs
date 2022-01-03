using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCommands
{
    public sealed class CellCancelCommand : GameCommand
    {
        public CellCancelCommand()
        {
            Category = CommandCategory.Cancel;
        }
    }
}