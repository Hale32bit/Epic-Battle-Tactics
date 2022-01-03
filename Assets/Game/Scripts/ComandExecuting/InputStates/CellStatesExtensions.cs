public static class CellStatesExtensions
{
    public static void HighlightON(this IStatable obj) => obj.StartState(StateType.Higlighted);
    public static void HighlightOFF(this IStatable obj) => obj.EndState(StateType.Higlighted);
    public static void Select(this IStatable obj) => obj.StartState(StateType.Selected);
    public static void Deselect(this IStatable obj) => obj.EndState(StateType.Selected);
}