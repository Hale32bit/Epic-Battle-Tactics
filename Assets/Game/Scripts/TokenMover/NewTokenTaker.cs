using DG.Tweening;
using UnityEngine;

public sealed class NewTokenTaker : TokenMoverToPrecamera , INewTokenTaker 
{
    private ITokenSpawner _spawner;

    public NewTokenTaker(
        ICommandsBlocker commandBlocker, 
        IPreCameraTokenContainer preCamera, 
        ITokenSpawner spawner) 
        : base(commandBlocker, preCamera)
    {
        _spawner = spawner;
    }

    public void Take()
    {
        var contanerWithNewToken = _spawner.Spawn();
        BindWithPreCamera(contanerWithNewToken);
        base.MoveToken(contanerWithNewToken, _preCamera);
    }
}
