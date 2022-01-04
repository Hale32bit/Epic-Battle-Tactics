using Codice.Client.BaseCommands.CheckIn.Progress;
using Materials;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[DisallowMultipleComponent]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(TokenTextureAzimuthPresenter))]
public class QuadView : MonoBehaviour
{
    [SerializeField] private TokenData _tokenData;

    private MeshRenderer _renderer;
    private TokenTextureAzimuthPresenter _presenter;

    private float _currentAthimuth = 0;
    [SerializeField] private  float Speed = 400f;

    private void Start()
    { 
        _renderer = GetComponent<MeshRenderer>();
        _presenter = GetComponent<TokenTextureAzimuthPresenter>();
        UpdateTextureAzimuth();
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
        _currentAthimuth = Mathf.MoveTowardsAngle(_currentAthimuth, _presenter.TargetAthimuth, Speed * Time.deltaTime);

        UpdateTextureAzimuth();
    }

    private void UpdateTextureAzimuth()
    {
        _renderer.material.SetMatrix(
            TokenQuadMaterial.Parameters.TextureAzimuth, 
            Matrix4x4.Rotate(Quaternion.Euler(0, 0,  -_currentAthimuth)));
    }
}
