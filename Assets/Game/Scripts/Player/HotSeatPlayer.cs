using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HotSeatPlayer : Player
{
    [Inject]
    private void Construct(Battlefield battlefield)
    {
        battlefield.Clicked += OnPointerEvent;
        battlefield.PointerEnter += OnPointerEvent;
        battlefield.PointerExit += OnPointerEvent;
    }

    protected void OnPointerEvent(WorldPointerEventData data)
    {
        if (AvaliableActions.TryParseToAction(data, out IGameCommand command))
            Client.Receive(command);
    }
}
