using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;


namespace EffectLaunchers
{
public class LauncherWithMinimalWorktime : EffectLauncher
{
        private float _startTime;
        private float _minimalWorktime;

        private IDisposable _stream;

        public LauncherWithMinimalWorktime(StateType RequiredType, float minimalWorktime) : base(RequiredType)
        {
            _minimalWorktime = minimalWorktime;
        }

        protected override void SpecificStart()
        {
            if (_stream!= null)
                _stream.Dispose();

            _startTime = Time.time;
            InvokeStarting();
        }

        protected override void SpecificStop()
        {
            if (Time.time > _startTime + _minimalWorktime)
                InvokeStoping();
                else
                _stream = Observable.EveryUpdate()
                    .Where(_ => this._startTime + this._minimalWorktime < Time.time)
                    .Subscribe(_ => OnMinimalWorktimeEnded());   
        }

        private void OnMinimalWorktimeEnded()
        {
            _stream.Dispose();
            InvokeStoping();
        }
}
}