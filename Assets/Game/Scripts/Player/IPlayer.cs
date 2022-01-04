public interface IPlayer
{
    PlayerConfig Config { get; }

    void Receive(AvaliableActionsList actions);
    void SetActive(bool value);
}