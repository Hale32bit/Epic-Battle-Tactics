using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPointerEventDataNew : IPointerEventData
{
    public GameObject Object { get; private set; }

    public WorldPointerEventType EventType { get; private set; }

    public WorldPointerEventDataNew(GameObject obj, WorldPointerEventType eventType)
    {
        Object = obj;
        EventType = eventType;
    }
}
