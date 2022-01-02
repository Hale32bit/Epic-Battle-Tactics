using DG.Tweening;
using UnityEngine;

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
        const float duration = 1f;

        var sequence = DOTween.Sequence();
        sequence.Append(initial.GetToken().transform.DOLocalMove(_preCamera.LocalCenter, duration));
        sequence.Join(initial.GetToken().transform
            .DOLocalRotate(new Vector3(-90f, 0 ,0) , duration, RotateMode.Fast));

        return sequence;
    }
}
