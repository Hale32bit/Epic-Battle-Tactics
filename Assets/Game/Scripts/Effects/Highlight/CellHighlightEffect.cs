using System;
using System.Collections;
using System.Collections.Generic;
using EffectLaunchers;
using UnityEngine;
using Zenject;

[DisallowMultipleComponent]
[RequireComponent(typeof(BattlefieldCell))]
public sealed class CellHighlightEffect : ParticleEffect
{
    private void Awake()
    {
        Launcher = new LauncherWithMinimalWorktime(StateType.Higlighted, 0.7f);
    }
}
