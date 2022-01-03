using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class AvaliableAction 
{
    protected GameCommand Command;

    protected virtual bool PredicateForObject(GameObject obj)
    {
        throw new Exception();
    }

    protected virtual bool PredicateForData(IDataForCommand data)
    {
        throw new Exception();
    }

    public bool IsMatch(WorldPointerEventData data)
    {
       return PredicateForData(data);
    }

    public bool TryGenerateCommand(WorldPointerEventData data, out IGameCommand command)
    {
        bool isSuccess = IsMatch(data);

        if (isSuccess)
        { 
            Command.Configure(data);
            command = Command;
        }
        else
            command = null;

        return isSuccess;
    }
}


