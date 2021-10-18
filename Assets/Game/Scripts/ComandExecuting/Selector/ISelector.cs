using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelector
{
    event Action<object> Selected;
    bool IsSelected(object obj);
    IStatable SelectedObject { get; }
}
