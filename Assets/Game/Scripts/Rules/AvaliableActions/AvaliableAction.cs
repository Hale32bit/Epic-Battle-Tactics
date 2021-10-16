using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
//using Zenject.ReflectionBaking.Mono.Cecil.Cil;

public abstract class AvaliableAction 
{
    protected GameCommand _command;

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
            _command.Configure(data);
            command = _command;
        }
        else
            command = null;

        return isSuccess;
    }
}


