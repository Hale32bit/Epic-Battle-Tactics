using UnityEngine;

namespace AvaliableActions
{
    public sealed class CellClockwiseRotateAction : AvaliableAction
    {
        public CellClockwiseRotateAction()
        {
            Command = new GameCommands.CellClockwiseRotateCommand();
        }

        protected override bool PredicateForData(IDataForCommand data)
        {
            return data.OriginalSource is CellClockwiseRotationButton &&
                data.EventType == PointerEventType.Click;
        }

        protected override bool PredicateForObject(GameObject obj)
        {
            return obj.GetComponent<CellClockwiseRotationButton>() != null;
        }
    }
}
