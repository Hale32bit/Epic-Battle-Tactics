using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EffectLaunchers
{
public sealed class SimpleLauncher : EffectLauncher
{
        public SimpleLauncher(StateType RequiredType) : base(RequiredType)
        {
        }

        protected override void SpecificStart()
        {
            InvokeStarting();
        }

        protected override void SpecificStop()
        {
            InvokeStoping();
        }
}
}