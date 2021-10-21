using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EffectLaunchers;

[DisallowMultipleComponent]
[RequireComponent(typeof(BattlefieldCell))]
public class CellSelectedEffect : ParticleEffect
{
    private const float MinimalWorktime = 0.5f;

    private void Awake()
    {
        Launcher = new LauncherWithMinimalWorktime(StateType.Selected, MinimalWorktime);
    }
}
