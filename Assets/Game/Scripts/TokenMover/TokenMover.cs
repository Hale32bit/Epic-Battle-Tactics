using DG.Tweening;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public sealed class TokenMover : ITokenMover
{
    private ICommandsBlocker _commandBlocker;
    
    [Inject]
    private void Construct(ICommandsBlocker commandBlocker)
    {
        _commandBlocker = commandBlocker;
    }
   
    public void MoveToken(ITokenContainer initial, ITokenContainer target)
    {
        Tween tween = GenerateTweenForMoving((dynamic)initial, (dynamic)target);

        LockCommandsUntilMovingComplited(tween);

        Reattach(initial, target);
    }

    private static void Reattach(ITokenContainer initial, ITokenContainer target)
    {
        Token token = initial.Release();
        target.Attach(token);
    }

    private void LockCommandsUntilMovingComplited(Tween tween)
    {
        _commandBlocker.Lock();
        tween.OnComplete(new TweenCallback(() => _commandBlocker.Unlock()));
    }

    private Tween GenerateTweenForMoving(SpawnedTokenContainer initial, IPreCameraTokenContainer target)
    {
        return initial.GetToken().transform.DOMove(target.Transform.TransformPoint(target.LocalCenter), 2);
    }
}
