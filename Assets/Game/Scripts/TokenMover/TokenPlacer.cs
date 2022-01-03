using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenPlacer : TokenMover, ITokenPlacer
{
    private IPreCameraTokenContainer _preCamera;

    public TokenPlacer(ICommandsBlocker commandBlocker, IPreCameraTokenContainer preCamera) : base(commandBlocker)
    {
        _preCamera = preCamera;
    }

    public void Place(BattlefieldCell destination)
    {
        BindWithCell(destination);
        base.MoveToken(_preCamera, destination);
    }

    private void BindWithCell(BattlefieldCell destination)
    {
        _preCamera
            .GetToken()
            .transform
            .SetParent(destination.transform, true);
    }

    protected override Tween GenerateTweenForMoving(ITokenContainer initial, ITokenContainer target)
    {
        const float duration = 1f;

        var transform = initial.GetToken().transform;

        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(target.Transform.position, duration));
        sequence.Join(transform.DORotate(new Vector3(0, 0, 0), duration, RotateMode.Fast));

        return sequence;
    }
}
