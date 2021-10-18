using Materials;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[DisallowMultipleComponent]
[RequireComponent(typeof(MeshRenderer))]
public class QuadView : MonoBehaviour
{
    [SerializeField]
    private TokenData _tokenData;

    private Transform _camera;
    private MeshRenderer _renderer;

    [Inject]
    private void Construct(Camera camera)
    {
        _camera = camera.transform;
        _renderer = GetComponent<MeshRenderer>();

        SetTokenData(_tokenData);
    }

    private void SetTokenData(TokenData data)
    {
        _tokenData = data;
        _renderer.material.SetTexture(TokenQuadMaterial.Parameters.MainTexture, _tokenData.MainTexture);
        _renderer.material.SetTexture(TokenQuadMaterial.Parameters.Iconographic, _tokenData.IconographicTexture);
        _renderer.material.SetTexture(TokenQuadMaterial.Parameters.IconographicRotatable, _tokenData.IconographicTextureRotatable);
    }

    void Update()
    {
        _renderer.material.SetMatrix(TokenQuadMaterial.Parameters.TextureAzimuth, Matrix4x4.Rotate(Quaternion.Euler(0, 0, -_camera.rotation.eulerAngles.y))) ;
    }
}
