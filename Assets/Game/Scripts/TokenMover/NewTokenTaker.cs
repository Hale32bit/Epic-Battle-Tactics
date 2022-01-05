using DG.Tweening;
using UnityEngine;

public sealed class NewTokenTaker : TokenMoverToPrecamera , INewTokenTaker 
{
    private IPlayerTurn _playerTurn;

    public NewTokenTaker(
        ICommandsBlocker commandBlocker, 
        IPreCameraTokenContainer preCamera,
        IPlayerTurn playerTurn) 
        : base(commandBlocker, preCamera)
    {
        _playerTurn = playerTurn;
    }

    public void Take()
    {
        var contanerWithNewToken = _playerTurn.CurrentPlayer.Spawner.Spawn();
        BindWithPreCamera(contanerWithNewToken);
        base.MoveToken(contanerWithNewToken, _preCamera);
    }
}
