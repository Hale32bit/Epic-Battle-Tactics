using UnityEngine;

namespace AvaliableActions
{
    public class HighlightOFF : AvaliableAction
    {
        public HighlightOFF()
        {
            Command = new GameCommands.HiglightOFF();
        }

        protected override bool PredicateForData(IDataForCommand data)
        {
            return data.Container is BattlefieldCell
                && data.EventType == PointerEventType.Exit;
        }

        protected override bool PredicateForObject(GameObject obj)
        {
            return obj.GetComponent<BattlefieldCell>() != null;
        }
    }
}

