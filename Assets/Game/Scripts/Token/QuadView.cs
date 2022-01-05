using Codice.Client.BaseCommands.CheckIn.Progress;
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
    private MeshRenderer _renderer;
    private IQuadAzimuthProvider _azimuthProvider;

    private float _currentAthimuth = 0;
    [SerializeField] private  float Speed = 400f;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    { 
        UpdateTextureAzimuth();
    }

    internal void Initialize(IQuadAzimuthProvider azimuthProvider)
    {
        _azimuthProvider = azimuthProvider;
    }

    void Update()
    {
        _currentAthimuth = Mathf.MoveTowardsAngle(_currentAthimuth, _azimuthProvider.TargetAthimuth, Speed * Time.deltaTime);

        UpdateTextureAzimuth();
    }

    internal void SetData(TokenData data)
    {
        Debug.Log(data);
        Debug.Log(data.MainTexture);

        _renderer.material.SetTexture(TokenQuadMaterial.Parameters.MainTexture, data.MainTexture);
        _renderer.material.SetTexture(TokenQuadMaterial.Parameters.Iconographic, data.IconographicTexture);
        _renderer.material.SetTexture(TokenQuadMaterial.Parameters.IconographicRotatable, data.IconographicTextureRotatable);
    }

    private void UpdateTextureAzimuth()
    {
        _renderer.material.SetMatrix(
            TokenQuadMaterial.Parameters.TextureAzimuth, 
            Matrix4x4.Rotate(Quaternion.Euler(0, 0,  -_currentAthimuth)));
    }
}
