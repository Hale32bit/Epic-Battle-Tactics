using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using Zenject;

public class PreCameraPanel : TokenContainer
{
    private const float WidthInScreenCoords = 0.16f;
    private const float EdgeIndentInScreenCoords = 0.04f;

    public const float LeftMarginInScreenCoords = 1f - WidthInScreenCoords - EdgeIndentInScreenCoords;
    public const float RightMarginInScreenCoords = 1f - EdgeIndentInScreenCoords;
    public const float BottomMarginInScreenCoords = EdgeIndentInScreenCoords;


    private float _depthOfPanel;
    public Vector3 LocalCenter { get; private set; }
    
    [SerializeField]
    private GameObject _markerPrefab;

    private Camera _camera;

    [Inject]
    private void Construct(Camera camera)
    {
        _camera = camera;
    }

    private void Start()
    {
        LocalCenter = CalculateCenter();

        var marker = Instantiate(_markerPrefab, _camera.transform);
        marker.transform.localPosition = LocalCenter;

    }

    private Vector3 CalculateCenter()
    {
        const int LeftBottomCornerIndex = 0;
        const int LeftTopCornerIndex = 1;
        const int RightTopCornerIndex = 2;
        const int RightBottomCornerIndex = 3;

        var panelRect = new Rect(
            LeftMarginInScreenCoords,
            BottomMarginInScreenCoords,
            WidthInScreenCoords,
            1f);

        var corners = new Vector3[4];
        _camera.CalculateFrustumCorners(panelRect, 1f, Camera.MonoOrStereoscopicEye.Mono, corners);

        Vector3 leftToRightVector = corners[RightBottomCornerIndex] - corners[LeftBottomCornerIndex];
        Vector3 bottomToTopVector = corners[LeftTopCornerIndex] - corners[LeftBottomCornerIndex];

        float physicalWidthPerDepth = leftToRightVector.magnitude;

        Vector3 central =
            corners[LeftBottomCornerIndex] + leftToRightVector / 2f +
            bottomToTopVector.normalized * physicalWidthPerDepth / 2f;

        _depthOfPanel =
            ProceduralGeneratedMeshes.TokenEdgeGenerator.PhysicalWidth / physicalWidthPerDepth;

        return central * _depthOfPanel;
    }
}
