using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EffectLaunchers
{

    public abstract class EffectLauncher
    {
        public event Action Starting;
        public event Action Stoping; 

        private StateType _requiredType;

        public EffectLauncher(StateType RequiredType)
        {
            _requiredType = RequiredType;
        }

        public void Stop(StateType stateType)
        {
            if (stateType != _requiredType)
                return;

            SpecificStop(); 
        }

        protected abstract void SpecificStop();
        
        public void Start(StateType stateType)
        {
            if (stateType != _requiredType)
                return;

            SpecificStart();
        }

        protected abstract void SpecificStart();

        protected void InvokeStarting() => Starting?.Invoke();

        protected void InvokeStoping() => Stoping?.Invoke();


    }
}