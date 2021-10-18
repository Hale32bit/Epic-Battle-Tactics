using AvaliableActions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[DisallowMultipleComponent]
public sealed class Highlighter : CommandExecutor
{
    private IStatable _higlited;

    private ISelector _selector;

    [Inject]
    private void Construct(ISelector selector)
    {
        _selector = selector;
        _selector.Selected += OnSelected;
    }

    private void OnSelected(object obj)
    {
        if (obj == _higlited)
            HighlightOFF();
    }

    protected override void OnGateLocked()
    {
        HighlightOFF();
    }

    protected override void OnCommand(IGameCommand command)
    {
        if (command.IsHighliting())
            Process(command);
    }

    private void Process(IGameCommand command)
    {
        if (command.Category == CommandCategory.HighlightON)
            TryHighlightON(command.Container as IStatable);
        else
            HighlightOFF();
    }

    private void HighlightOFF()
    {
        if (_higlited == null)
            return;

        _higlited.HighlightOFF();
        _higlited = null;
    }

    private bool TryHighlightON(IStatable obj)
    {
        Debug.Log(_selector.IsSelected(obj));
        if (_selector.IsSelected(obj))
            return false;

        if (_higlited != null)
            HighlightOFF();

        _higlited = obj;
        _higlited.HighlightON();

        return true;
    }
}
