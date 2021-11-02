using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Zenject;

public sealed class UIEventRoot : WorldPointerHandler
{
    private PreCameraTokenButton _panel;

    [Inject]
    private void Construct(PreCameraTokenButton panel)
    {
        _panel = panel;     
    }

    private void OnEnable()
    {
        SubscribeToChild(_panel);
    }

    private void OnDisable()
    {
        UnsubscribeFromChild(_panel);
    }
}
