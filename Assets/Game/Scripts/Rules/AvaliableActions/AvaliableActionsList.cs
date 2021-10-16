using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvaliableActionsList 
{
    readonly List<AvaliableAction> _avaliables = new List<AvaliableAction>(); 
    
    public AvaliableActionsList(AvaliableAction[] avaliables)
    {
        _avaliables.AddRange(avaliables);
    }

    public bool TryParseToAction(WorldPointerEventData data, out IGameCommand action)
    {
        foreach (var avaliable in _avaliables)
        {
            if (avaliable.TryGenerateCommand(data, out action))
                return true;
        }

        action = null;
        return false;
    }
    

}

