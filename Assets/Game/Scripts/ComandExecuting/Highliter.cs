using AvaliableActions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Highliter : MonoBehaviour
{
    private IHiglitable _higlited; 

    [Inject]
    private void Construct(IGameCommandGate gate)
    {
        gate.CommandReceived += OnCommand;
        gate.BecomeLocked += OnGateLocked;
    }

    private void OnGateLocked()
    {
        HighlightOFF();
    }

    private void OnCommand(IGameCommand command)
    {
        if (command.IsHiliting())
            Process(command);
    }

    private void Process(IGameCommand command)
    {
        if (command.Category == CommandCategory.HighlightON)
            HighlightON(command.Container as IHiglitable);
        else
            HighlightOFF();
    }

    private void HighlightOFF()
    {
        if (_higlited == null)
            return;


        _higlited.HiglightOFF();
        _higlited = null;
    }

    private void HighlightON(IHiglitable higlitable)
    {
        if (_higlited != null)
            HighlightOFF();

        higlitable.HiglightON();
        _higlited = higlitable;
    }
}
