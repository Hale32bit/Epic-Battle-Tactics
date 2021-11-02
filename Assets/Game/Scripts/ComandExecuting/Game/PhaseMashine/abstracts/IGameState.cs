namespace GameStates
{
    public interface IGameState : IGameStatePublisher
    {
        void ExecuteCommand(IGameCommand command);
        void Initialize(IStateParent patent);
        void Start();
        void Stop();
    }
}