using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="UI/CellPanelCofig")]
public sealed class CellPanelConfig : ScriptableObject
{
    [SerializeField] private bool _acceptButtonEnabled;
    public bool AcceptButtonEnabled => _acceptButtonEnabled;

    [SerializeField] private bool _cancelButtonEnabled;
    public bool CancelButtonEnabled => _cancelButtonEnabled;

    [SerializeField] private bool _rotateButtonsEnabled;
    public bool RotateButtonEnabled => _rotateButtonsEnabled;
}
