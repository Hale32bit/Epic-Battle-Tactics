using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using Zenject;

[SerializeField]
public class TokenGeometry : MonoBehaviour
{
    [SerializeField] private Transform _nePoint;
    [SerializeField] private Transform _nwPoint;
    [SerializeField] private Transform _sePoint;
    [SerializeField] private Transform _swPoint;

    public Vector3 NEPoint => _nePoint.position;
    public Vector3 NWPoint => _nwPoint.position;
    public Vector3 SEPoint => _sePoint.position;
    public Vector3 SWPoint => _swPoint.position;

    public Vector3 NEScreenPoint { get; private set; }
    public Vector3 NWScreenPoint { get; private set; }
    public Vector3 SEScreenPoint { get; private set; }
    public Vector3 SWScreenPoint { get; private set; }

    public float ScreenMinX { get; private set; }
    public float ScreenMaxX { get; private set; }
    public float ScreenMinY { get; private set; }
    public float ScreenMaxY { get; private set; }

    private Camera _camera;

    [Inject]
    private void Construct(Camera camera)
    {
        _camera = camera;
    }

    private void Update()
    {
        CalculateScreenPoints();
        DefineBounds();
    }

    private void DefineBounds()
    {
        DefineMaxX();
        DefineMaxY();
        DefineMinX();
        DefineMinY();
    }

    private void DefineMinY()
    {
        ScreenMinY = Mathf.Min(NEScreenPoint.y, NWScreenPoint.y);
        ScreenMinY = Mathf.Min(ScreenMinY, SEScreenPoint.y);
        ScreenMinY = Mathf.Min(ScreenMinY, SWScreenPoint.y);
    }

    private void DefineMinX()
    {
        ScreenMinX = Mathf.Min(NEScreenPoint.x, NWScreenPoint.x);
        ScreenMinX = Mathf.Min(ScreenMinX, SEScreenPoint.x);
        ScreenMinX = Mathf.Min(ScreenMinX, SWScreenPoint.x);
    }

    private void DefineMaxY()
    {
        ScreenMaxY = Mathf.Max(NEScreenPoint.y, NWScreenPoint.y);
        ScreenMaxY = Mathf.Max(ScreenMaxY, SEScreenPoint.y);
        ScreenMaxY = Mathf.Max(ScreenMaxY, SWScreenPoint.y);
    }

    private void DefineMaxX()
    {
        ScreenMaxX = Mathf.Max(NEScreenPoint.x, NWScreenPoint.x);
        ScreenMaxX = Mathf.Max(ScreenMaxX, SEScreenPoint.x);
        ScreenMaxX = Mathf.Max(ScreenMaxX, SWScreenPoint.x);
    }

    private void CalculateScreenPoints()
    {
        NEScreenPoint = _camera.WorldToScreenPoint(NEPoint);
        NWScreenPoint = _camera.WorldToScreenPoint(NWPoint);
        SEScreenPoint = _camera.WorldToScreenPoint(SEPoint);
        SWScreenPoint = _camera.WorldToScreenPoint(SWPoint);
    }
}
