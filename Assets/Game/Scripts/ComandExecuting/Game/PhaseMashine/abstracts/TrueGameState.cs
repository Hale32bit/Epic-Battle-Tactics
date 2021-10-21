using System;
using System.Collections;
using System.Collections.Generic;
namespace GameStates
{
    public abstract class TrueGameState<TActionsList> : GameState, IEnumerable<IGameStatePublisher>
    where TActionsList : AvaliableActionsList , new()
    {
        private readonly AvaliableActionsList _actionsList;

        protected TrueGameState(IStateParent parent) : base(parent)
        {
            _actionsList = new TActionsList();
        }

        protected override sealed void ApplyActionsList()
        {
            Parent.Receive(_actionsList);
        }

        public IEnumerator<IGameStatePublisher> GetEnumerator()
        {
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield break;
        }

        public override sealed IEnumerable<IGameStatePublisher> States() 
        {
            return this;
        }
    }
}
