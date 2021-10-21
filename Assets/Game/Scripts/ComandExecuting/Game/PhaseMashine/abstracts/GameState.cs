using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameStates
{
    public abstract class GameState : IGameStatePublisher
    {
        protected readonly IStateParent Parent;

        public event Action Started;
        public event Action Stoped;

        public GameState(IStateParent parent)
        {
            Parent = parent;
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

        protected void DoNothing() { }

        public abstract void ExecuteCommand(IGameCommand command);

        public abstract IEnumerable<IGameStatePublisher> States();

        protected abstract void OnStarted();

        protected abstract void OnStoped();

        protected abstract void ApplyActionsList();
    }
}
