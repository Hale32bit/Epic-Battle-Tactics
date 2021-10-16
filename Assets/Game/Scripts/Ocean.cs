using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Ocean : MonoBehaviour
{
    public const float YLevel = -3f;

    void Start()
    {
        this.transform.position = Vector3.up * YLevel;
    }
}
