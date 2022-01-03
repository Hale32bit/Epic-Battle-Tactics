using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public sealed class CellPanel : WorldPointerHandler, ICellPanel
{
    public event Action BecomeUnvisible;
    public event Action<BattlefieldCell> DestinationChanged;
    public event Action<CellPanelConfig> ConfigChanged;

    public CellPanelConfig Config { get; private set; }

    public bool Visible { get; private set; } = false;
    public BattlefieldCell Destination { get; private set; }

    [SerializeField] private WorldPointerHandler[] _buttons;


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
        if (Destination == value && Visible)
            return;

        Visible = true;
        Destination = value;
        DestinationChanged?.Invoke(Destination);
    }

    internal void SetConfig(CellPanelConfig value)
    {
        Config = value;
        ConfigChanged?.Invoke(Config);
    }

    public void SetUnvisible()
    {
        if (Visible == false)
            return;

        Visible = false;
        BecomeUnvisible?.Invoke();
    }
}
