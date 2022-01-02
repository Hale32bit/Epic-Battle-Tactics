using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(MeshRenderer))]
public sealed class BilboardView : MonoBehaviour
{
    [SerializeField] private Texture2D _currentTexture;

    private MeshRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        SetTexture(_currentTexture);
    }

    public void SetTexture(Texture2D value)
    {
        _renderer.material.SetTexture(BillboardMaterial.Parameters.MainTexture, value);       
    }
}
