using UnityEngine;

namespace GameStates.Phase1Space
{
    public sealed class TakeTokenAction : AvaliableAction
    {
        public TakeTokenAction()
        {
           _command = new TakeTokenCommand();
        }

        protected override bool PredicateForData(IDataForCommand data)
        {

            return data.OriginalSource is PreCameraTokenButton
                 && data.EventType == PointerEventType.Click;
        }

        protected override bool PredicateForObject(GameObject obj)
        {
            return obj.GetComponent<PreCameraTokenButton>() != null;
        }
    }
}