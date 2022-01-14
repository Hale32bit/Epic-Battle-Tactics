using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public sealed class WorldPointerHandler_new : ITickable
{
    public const float RaycastDistance = 40f;

    public event Action<WorldPointerEventDataNew> Clicked;


    private List<RaycastResult> _raycastResults = new List<RaycastResult>(5);

    private WorldPointerInput _pointerInput;
    private Camera _camera;

    public WorldPointerHandler_new(WorldPointerInput pointerInput, Camera camera)
    {
        _pointerInput = pointerInput;
        _camera = camera;
        _pointerInput.LeftClicked += OnLeftClicked;
        _pointerInput.RightClicked += OnRightClicked;
    }

    private void OnRightClicked()
    {
        GameObject obj = TryGetObjectByCameraRaycast();
        var eventData = new WorldPointerEventDataNew(obj, WorldPointerEventType.LeftClick);
        Clicked?.Invoke(eventData);
    }

    private void OnLeftClicked()
    {
        GameObject obj = TryGetObjectByCameraRaycast();
        var eventData = new WorldPointerEventDataNew(obj, WorldPointerEventType.RightClick);
        Clicked?.Invoke(eventData);
    }

    private GameObject TryGetObjectByCameraRaycast()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject;

        if (obj != null)
            return obj;

        obj = TryGetObjectByPhysicsRaycast();

        return obj;
    }
    private GameObject TryGetObjectByPhysicsRaycast()
    {
        GameObject obj;
        Vector3 mousePosition = _pointerInput.MousePosition;
        var ray = _camera.ScreenPointToRay(new Vector3(mousePosition.x, mousePosition.y));
        Physics.Raycast(ray, out RaycastHit hit, RaycastDistance);
        obj = (hit.transform == null ? null : hit.transform.gameObject);
        return obj;
    }

    void ITickable.Tick()
    {

    }
}
