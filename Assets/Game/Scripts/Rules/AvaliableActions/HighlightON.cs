using UnityEngine;

namespace AvaliableActions
{
    public class HighlightON : AvaliableAction
    {
        public HighlightON()
        {
            Command = new GameCommands.HiglightON();
        }

        protected override bool PredicateForData(IDataForCommand data)
        {
           return data.Container is BattlefieldCell
                && data.EventType == PointerEventType.Enter;
        }

        protected override bool PredicateForObject(GameObject obj)
        {
            return obj.GetComponent<BattlefieldCell>() != null;
        }
    }
}

