using Castle.DynamicProxy.Generators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AvaliableActions
{
    public sealed class CellCancelAction : AvaliableAction
    {
        public CellCancelAction()
        {
            Command = new GameCommands.CellCancelCommand();
        }

        protected override bool PredicateForData(IDataForCommand data)
        {
            return data.OriginalSource is CellCancelButton &&
                data.EventType == PointerEventType.Click;
        }

        protected override bool PredicateForObject(GameObject obj)
        {
            return obj.GetComponent<CellCancelButton>() != null;
        }
    }
}
