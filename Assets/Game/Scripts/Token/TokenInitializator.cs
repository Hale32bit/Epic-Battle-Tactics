using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider))]
public class TokenInitializator : MonoBehaviour
{
    void Start()
    {
        var box = GetComponent<BoxCollider>();
        box.center = Vector3.up * ProceduralGeneratedMeshes.TokenEdgeGenerator.PhisicalHeight / 2f;
        box.size = new Vector3(
            ProceduralGeneratedMeshes.TokenEdgeGenerator.PhysicalWidth,
            ProceduralGeneratedMeshes.TokenEdgeGenerator.PhisicalHeight,
            ProceduralGeneratedMeshes.TokenEdgeGenerator.PhysicalWidth
            );

    }

}
