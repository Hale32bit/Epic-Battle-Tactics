using DG.Tweening;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class TokenMover 
{
    private ICommandsBlocker _commandBlocker;
    
    public TokenMover(ICommandsBlocker commandBlocker)
    {
        _commandBlocker = commandBlocker;
    }
   
    public void MoveToken(ITokenContainer initial, ITokenContainer target)
    {
        Tween tween = GenerateTweenForMoving((dynamic)initial, (dynamic)target);

        if (tween != null)
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

    protected abstract Tween GenerateTweenForMoving(ITokenContainer initial, ITokenContainer target);

}
