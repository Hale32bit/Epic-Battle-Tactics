using System.Collections.Generic;
using GameStates;

internal interface IGameStatesProvider
{
   IGameStatePublisher GetGameState<TState>() where TState : IGameStatePublisher; 
}