using UnityEngine;

namespace AvaliableActions
{
    public sealed class CellCounterclockwiseRotateAction : AvaliableAction
    {
        public CellCounterclockwiseRotateAction()
        {
            Command = new GameCommands.CellCounterclockwiseRotateCommand();
        }

        protected override bool PredicateForData(IDataForCommand data)
        {
            return data.OriginalSource is CellCounterclockwiseRotationButton &&
                data.EventType == PointerEventType.Click;
        }

        protected override bool PredicateForObject(GameObject obj)
        {
            return obj.GetComponent<CellCounterclockwiseRotationButton>() != null;
        }
    }

}
