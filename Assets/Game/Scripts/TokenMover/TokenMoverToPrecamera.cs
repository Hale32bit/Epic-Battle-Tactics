using DG.Tweening;
using UnityEngine;

public abstract class TokenMoverToPrecamera : TokenMover
{
    protected IPreCameraTokenContainer _preCamera;

    public TokenMoverToPrecamera(
        ICommandsBlocker commandBlocker,
        IPreCameraTokenContainer preCamera)
        : base(commandBlocker)
    {
        _preCamera = preCamera;
    }

    protected sealed override Tween GenerateTweenForMoving(ITokenContainer initial, ITokenContainer target)
    {
        const float duration = 1f;

        var transform = initial.GetToken().transform;

        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMove(_preCamera.LocalCenter, duration));
        sequence.Join(transform.DOLocalRotate(new Vector3(-90f, 0, 0), duration, RotateMode.Fast));

        return sequence;
    }

    protected void BindWithPreCamera(ITokenContainer container)
    {
        container
            .GetToken()
            .transform
            .SetParent(_preCamera.Transform);
    }
}
