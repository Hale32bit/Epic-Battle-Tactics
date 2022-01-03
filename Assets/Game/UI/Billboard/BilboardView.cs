using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(MeshRenderer), typeof(Collider))]
public sealed class BilboardView : MonoBehaviour
{
    [SerializeField] private Texture2D _currentTexture;
    [SerializeField] private float _currentAlpha = 0.5f;

    private MeshRenderer _renderer;
    private Collider _collider;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
        SetTexture(_currentTexture);
        SetAlpha(_currentAlpha);
    }

    public void SetTexture(Texture2D value)
    {
        _currentTexture = value;
        _renderer.material.SetTexture(BillboardMaterial.Parameters.MainTexture, _currentTexture);       
    }

    public void SetAlpha(float value)
    {
        _currentAlpha = value;
        _renderer.material.SetFloat(BillboardMaterial.Parameters.Alpha, _currentAlpha);
    }

    public void ColliderON()
    {
        _collider.enabled = true;
    }

    public void ColliderOFF()
    {
        _collider.enabled = false;
    }

}
