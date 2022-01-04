using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ReturnerToPrecamera : TokenMover, IReturnerToPrecamera
{
    private IPreCameraTokenContainer _preCamera;
    private ICellPanel _cellPanel; 


    public ReturnerToPrecamera(
        ICommandsBlocker commandBlocker,
        IPreCameraTokenContainer preCamera,
        ICellPanel cellPanel) 
        : base(commandBlocker)
    {
        _preCamera = preCamera;
        _cellPanel = cellPanel;
    }
    public void Return()
    {
        BindWithPreCamera(_cellPanel.Destination);

        base.MoveToken(_cellPanel.Destination, _preCamera);
    }

    private void BindWithPreCamera(ITokenContainer container)
    {
        container
            .GetToken()
            .transform
            .SetParent(_preCamera.Transform);
    }

    protected override Tween GenerateTweenForMoving(ITokenContainer initial, ITokenContainer target)
    {
        const float duration = 1f;

        var transform = initial.GetToken().transform;

        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMove(_preCamera.LocalCenter, duration));
        sequence.Join(transform.DOLocalRotate(new Vector3(-90f, 0, 0), duration, RotateMode.Fast));

        return sequence;
    }
}
