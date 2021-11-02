using System.Collections;
using System.Collections.Generic;

namespace GameStates.Phase1Space
{
    public sealed class TakeTokenActionsList : AvaliableActionsList
    {
        public TakeTokenActionsList()
        {

            Avaliables = new AvaliableAction[]
                {
                new TakeTokenAction(),
                new AvaliableActions.HighlightON(),
                new AvaliableActions.HighlightOFF()
                };
        }
    }
}