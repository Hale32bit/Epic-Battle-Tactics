using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public sealed class Selector : CommandExecutor, ISelector
{
    public IStatable SelectedObject { get; private set; }

    public event Action<object> Selected;

    public bool IsSelected(object obj) => obj == SelectedObject;
    
    protected override void OnCommand(IGameCommand command)
    {
        if (command.Category != CommandCategory.Targeting)
            return;

        if (SelectedObject != null)
            SelectedObject.Deselect();

        SelectedObject = command.Container as IStatable;
        SelectedObject.Select();
        Selected?.Invoke(SelectedObject);

        
    }

    protected override void OnGateLocked()
    {
        
    }
}
