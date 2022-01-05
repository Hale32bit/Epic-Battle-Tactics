using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public sealed class HotSeatPlayer : Player
{
    public HotSeatPlayer(
        IGameCommandClient client,
        Battlefield battlefield,
        ITokenSpawner spawner,
        UIEventRoot uiRoot,
        PlayerConfig config)
        : base(client, config, spawner)
    {
        uiRoot.Clicked += OnPointerEvent;
        uiRoot.PointerEnter += OnPointerEvent;
        uiRoot.PointerExit += OnPointerEvent;

        battlefield.Clicked += OnPointerEvent;
        battlefield.PointerEnter += OnPointerEvent;
        battlefield.PointerExit += OnPointerEvent;
    }

    private void OnPointerEvent(WorldPointerEventData data)
    {
        if (Active == false)
            return;

        if (AvaliableActions.TryParseToAction(data, out IGameCommand command))
            Client.Receive(command);
    }
}
