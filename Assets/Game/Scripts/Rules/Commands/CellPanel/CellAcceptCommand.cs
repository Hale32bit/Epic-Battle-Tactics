using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameCommands
{
    public class CellAcceptCommand : GameCommand
    {
        public CellAcceptCommand()
        {
            Category = CommandCategory.Accept;
        }
    }
}