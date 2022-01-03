using ICSharpCode.NRefactory.Ast;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AvaliableActions
{
    public class CellAcceptAction : AvaliableAction
    {
        public CellAcceptAction()
        {
            Command = new GameCommands.CellAcceptCommand();
        }

        protected override bool PredicateForData(IDataForCommand data)
        {
            return data.OriginalSource is CellAcceptButton &&
                data.EventType == PointerEventType.Click;
        }

        protected override bool PredicateForObject(GameObject obj)
        {
            return obj.GetComponent<CellAcceptButton>() != null;
        }
    }
}