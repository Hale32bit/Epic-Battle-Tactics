using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvaliableActionsList 
{
    protected AvaliableAction[] Avaliables; 
    
    public bool TryParseToAction(WorldPointerEventData data, out IGameCommand action)
    {
        foreach (var avaliable in Avaliables)
        {
            if (avaliable.TryGenerateCommand(data, out action))
                return true;
        }

        action = null;
        return false;
    }
}

