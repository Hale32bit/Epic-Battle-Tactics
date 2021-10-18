using EffectLaunchers;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    protected EffectLauncher Launcher;

    private void OnEnable()
    {
        var cell = GetComponent<BattlefieldCell>();
        Launcher.Starting += EffectON;
        Launcher.Stoping += EffectOFF;
        cell.StateStarted += Launcher.Start;
        cell.StateEnded += Launcher.Stop;
    }

    private void OnDisable()
    {
        var cell = GetComponent<BattlefieldCell>();
        Launcher.Starting -= EffectON;
        Launcher.Stoping -= EffectOFF;
        cell.StateStarted -= Launcher.Start;
        cell.StateEnded -= Launcher.Stop;
    }

    protected abstract void EffectON();

    protected abstract void EffectOFF();
}