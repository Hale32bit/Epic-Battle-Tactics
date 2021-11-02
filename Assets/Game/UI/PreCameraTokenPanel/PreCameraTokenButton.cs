using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine.EventSystems;

public class PreCameraTokenButton : WorldPointerHandler
{
    public void TakeTokenClick()
    {
        this.OnPointerClick(default(PointerEventData));
    }
}
