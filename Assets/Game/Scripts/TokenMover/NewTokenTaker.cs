using DG.Tweening;

public sealed class NewTokenTaker : TokenMover , INewTokenTaker 
{
    private IPreCameraTokenContainer _preCamera;
    private ITokenSpawner _spawner;

    public NewTokenTaker(ICommandsBlocker commandBlocker, IPreCameraTokenContainer preCamera, ITokenSpawner spawner) : base(commandBlocker)
    {
        _preCamera = preCamera; 
        _spawner = spawner;
    }

    public void Take()
    {
        var contanerWithNewToken = _spawner.Spawn();

        BindWithPreCamera(contanerWithNewToken);

        base.MoveToken(contanerWithNewToken, _preCamera);
    }

    private void BindWithPreCamera(ISpawnedTokenContainer contanerWithNewToken)
    {
        contanerWithNewToken
            .GetToken()
            .transform
            .SetParent(_preCamera.Transform);
    }

    protected override Tween GenerateTweenForMoving(ITokenContainer initial, ITokenContainer target)
    {
        return initial.GetToken().transform.DOLocalMove(
            _preCamera.Transform.TransformPoint(_preCamera.LocalCenter), 2);
    }
}
