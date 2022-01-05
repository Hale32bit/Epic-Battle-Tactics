using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Token))]
public class TokenEdgePresenter : MonoBehaviour
{
    [SerializeField] private MeshRenderer _edgeRenderer;

    private Token _token;

    private void Awake()
    {
        _token = GetComponent<Token>();
    }
}
