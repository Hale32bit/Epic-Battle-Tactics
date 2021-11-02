public interface IDataForCommand
{
    Token Token { get; }
    ITokenContainer Container { get; }
    PointerEventType EventType { get; }
    WorldPointerHandler OriginalSource { get; }
}


