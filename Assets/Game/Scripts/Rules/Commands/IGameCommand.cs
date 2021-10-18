public interface IGameCommand
{
    CommandCategory Category { get; }
    ITokenContainer Container { get; }
    Token Token { get; }

    bool IsHighliting();
}