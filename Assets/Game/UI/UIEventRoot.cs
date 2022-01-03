using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Zenject;

public sealed class UIEventRoot : WorldPointerHandler
{
    private PreCameraTokenButton _tokenPanel;
    private CellPanel _cellPanel;

    [Inject]
    private void Construct(
        PreCameraTokenButton tokenPanel, CellPanel cellPanel)
    {
        _tokenPanel = tokenPanel;
        _cellPanel = cellPanel;
    }

    private void OnEnable()
    {
        SubscribeToChild(_tokenPanel);
        SubscribeToChild(_cellPanel);
    }

    private void OnDisable()
    {
        UnsubscribeFromChild(_tokenPanel);
        UnsubscribeFromChild(_cellPanel);
    }
}
