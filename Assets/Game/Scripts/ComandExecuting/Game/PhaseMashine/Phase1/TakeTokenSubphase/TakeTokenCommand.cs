namespace GameStates.Phase1Space
{
    internal sealed class TakeTokenCommand : GameCommand
    {
        public TakeTokenCommand()
        {
            Category = CommandCategory.Take;
        }
    }
}