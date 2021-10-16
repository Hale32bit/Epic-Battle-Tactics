using UnityEngine;

namespace AvaliableActions
{
    public class SpawnOnBattlefield : AvaliableAction
    {
        public SpawnOnBattlefield()
        {
            _command = new GameCommands.SpawnOnBattlefield();
        }

        protected override bool PredicateForData(IDataForCommand data)
        {
            return data.Container is BattlefieldCell
                && data.Container.GetToken() == null
                && data.EventType == PointerEventType.Click;
        }

        protected override bool PredicateForObject(GameObject obj)
        {
             var cell = obj.GetComponent<BattlefieldCell>();

            return cell != null
                && cell.GetToken() == null;
        }
    }
}

