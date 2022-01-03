namespace GameCommands
{
    public sealed class CellClockwiseRotateCommand : GameCommand
    {
        public CellClockwiseRotateCommand()
        {
            Category = CommandCategory.ClockwiseRotate;
        }
    }
}