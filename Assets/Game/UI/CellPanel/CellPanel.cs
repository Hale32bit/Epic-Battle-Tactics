using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public sealed class CellPanel : WorldPointerHandler
{
    public event Action<bool> VisibleChanged;
    public event Action<BattlefieldCell> DestinationChanged;

    public bool Visible { get; private set; } = true;
    public BattlefieldCell Destination { get; private set; }

    [SerializeField] private WorldPointerHandler[] _buttons;

    private void Start()
    {
        SetUnvisible();
    }

    private void OnEnable()
    {
        foreach (var button in _buttons)
            SubscribeToChild(button);
    }

    private void OnDisable()
    {
        foreach (var button in _buttons)
            UnsubscribeFromChild(button);
    }

    public void SetDestination(BattlefieldCell value)
    {
        if (Destination == value)
            return;

        Destination = value;
        DestinationChanged?.Invoke(Destination);

        SetVisible();
    }

    private void SetVisible()
    {
        if (Visible)
            return;

        Visible = true;
        VisibleChanged?.Invoke(Visible);
    }

    public void SetUnvisible()
    {
        if (Visible == false)
            return;

        Visible = false;
        VisibleChanged?.Invoke(Visible);
    }

}
