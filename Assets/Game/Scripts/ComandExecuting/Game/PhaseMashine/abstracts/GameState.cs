using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameStates
{
    public abstract class GameState : IGameState
    {
        public event Action Started;
        public event Action Stoped;

        private IStateParent _parent;
        protected IStateParent Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                if (value == null)
                    throw new Exception("Parent cannot be null");

                if (_parent != null)
                    throw new Exception("Parent already seted");

                _parent = value;
            }
        }

        public void Start()
        {
            Started?.Invoke();
            ApplyActionsList();
            OnStarted();
        }

        public void Stop()
        {
            Stoped?.Invoke();
            OnStoped();
        }

        public abstract void Initialize(IStateParent patent);

        public abstract void ExecuteCommand(IGameCommand command);

        protected abstract void OnStarted();

        protected abstract void OnStoped();

        protected abstract void ApplyActionsList();

        protected void DoNothing() { }
    }
}
