using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStates.Phase1Space
{
    public class PlaceAction : AvaliableAction
    {
        public PlaceAction()
        {
            Command = new PlaceCommand();
        }

        protected override bool PredicateForData(IDataForCommand data)
        {
            return  data.EventType == PointerEventType.Click &&
                data.Container is BattlefieldCell &&
                data.Container.IsEmpty;            
        }

        protected override bool PredicateForObject(GameObject obj)
        {
            return obj.GetComponent<BattlefieldCell>() != null &&
                obj.GetComponent<BattlefieldCell>().IsEmpty;
        }
    }
}

