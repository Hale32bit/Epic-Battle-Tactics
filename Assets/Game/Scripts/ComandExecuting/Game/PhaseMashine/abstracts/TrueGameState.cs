using System;
using System.Collections;
using System.Collections.Generic;
namespace GameStates
{
    public abstract class TrueGameState<TActionsList> : GameState
    where TActionsList : AvaliableActionsList , new()
    {
        private readonly AvaliableActionsList _actionsList;
        private readonly IAvaliableActionsClient _actionsClient;

        protected TrueGameState(IAvaliableActionsClient actionsClient)
        {
            _actionsList = new TActionsList();
            _actionsClient = actionsClient;
        }

        public override sealed void Initialize(IStateParent parent)
        {
            Parent = parent;
        }

        protected override sealed void ApplyActionsList()
        {
            _actionsClient.Receive(_actionsList);
        }
    }
}
