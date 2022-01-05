public interface IPlayer
{
    PlayerConfig Config { get; }
    ITokenSpawner Spawner { get; }

    void Receive(AvaliableActionsList actions);
    void SetActive(bool value);
}