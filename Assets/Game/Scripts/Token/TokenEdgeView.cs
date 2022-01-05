using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(MeshRenderer))]
public sealed class TokenEdgeView : MonoBehaviour
{
    private MeshRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    public void SetColor(Color value)
    {
        _renderer.material.SetColor(TokenEdgeMaterial.Parameters.MainColor, value);
    }
}
