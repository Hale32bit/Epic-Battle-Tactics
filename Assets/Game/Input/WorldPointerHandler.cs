using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

[DisallowMultipleComponent]
public abstract class WorldPointerHandler : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public event WorldPointerEvent Clicked;
    public event WorldPointerEvent PointerEnter;
    public event WorldPointerEvent PointerExit;

    protected void SubscribeToChild(WorldPointerHandler child)
    {
        child.Clicked += OnChildClicked;
        child.PointerEnter += OnChildPointerEnter;
        child.PointerExit += OnChildPointerExit;
    }

    protected void UnsubscribeFromChild(WorldPointerHandler child)
    {
        child.Clicked -= OnChildClicked;
        child.PointerEnter -= OnChildPointerEnter;
        child.PointerExit -= OnChildPointerExit;
    }

    private void OnChildPointerExit(WorldPointerEventData worldData)
    {
        worldData.AddSource(this);
        PointerExit?.Invoke(worldData);
    }

    private void OnChildPointerEnter(WorldPointerEventData worldData)
    {
        worldData.AddSource(this);
        PointerEnter?.Invoke(worldData);
    }

    private void OnChildClicked(WorldPointerEventData worldData)
    {
        worldData.AddSource(this);
        Clicked?.Invoke(worldData);
    }

    public void OnPointerClick(PointerEventData data)
    {
        var worldData = new WorldPointerEventData(this, PointerEventType.Click);
        Clicked?.Invoke(worldData);
    }

    public void OnPointerEnter(PointerEventData data)
    {
        var worldData = new WorldPointerEventData(this, PointerEventType.Enter);
        PointerEnter?.Invoke(worldData);
    }

    public void OnPointerExit(PointerEventData data)
    {
        var worldData = new WorldPointerEventData(this, PointerEventType.Exit);
        PointerExit?.Invoke(worldData);
    }


}
