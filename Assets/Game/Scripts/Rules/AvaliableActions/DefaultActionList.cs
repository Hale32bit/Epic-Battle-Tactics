namespace AvaliableActions
{
    public class DefaultActionList : AvaliableActionsList
    {
        public DefaultActionList()
        {
            Avaliables = new AvaliableAction[]
            { 
             new AvaliableActions.SpawnOnBattlefield(),
             new AvaliableActions.HighlightON(),
             new AvaliableActions.HighlightOFF()
            };
        }
    }
}

