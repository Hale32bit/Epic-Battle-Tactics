using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BattlefieldCell))]
public class CellHighlightEffect : MonoBehaviour
{
    void Start()
    {
        var cell = GetComponent<BattlefieldCell>();
        cell.Highlighted += OnHiglited;
        cell.HighlightedOFF += OnHighlightedOFF;
    }

    private void OnHighlightedOFF()
    {
        transform.position += Vector3.up * -0.1f;
    }

    private void OnHiglited()
    {
        transform.position += Vector3.up * 0.1f;
    }
}
