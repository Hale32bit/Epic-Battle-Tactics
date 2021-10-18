using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameStates
{
public abstract class GameState 
{
    protected readonly IStateSwitcher Switcher;

        public event Action Started;
        public event Action Stoped;

        public GameState(IStateSwitcher switcher)
        {
            Switcher = switcher;
        }

        public void Start()
        {
            Started?.Invoke();
        }

        public void Stop()
        {
            Stoped?.Invoke();
        }

        protected void DoNothing() {}

        public abstract void ExecuteCommand(IGameCommand command);
}
}
