using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(MeshRenderer))]
public class Ocean : MonoBehaviour
{
    [SerializeField] private float _yLevel = -3f;

    void Start()
    {
        this.transform.position = Vector3.up * _yLevel;
        GetComponent<MeshRenderer>().enabled = true;
    }
}
