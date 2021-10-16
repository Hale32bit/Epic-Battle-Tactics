using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(BoxCollider))]
[DisallowMultipleComponent]
public class Token : WorldPointerHandler
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

    public class Factory : PlaceholderFactory<Token> { }
}
