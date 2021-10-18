using UnityEngine;

public abstract class ParticleEffect : Effect
{
    [SerializeField] private ParticleSystem _particles;

    protected override sealed void EffectOFF()
    {
        _particles.Stop(false, ParticleSystemStopBehavior.StopEmitting);
    }

    protected override sealed void EffectON()
    {
        _particles.Play();
    }

}