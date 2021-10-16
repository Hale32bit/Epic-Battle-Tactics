using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameCommandClient 
{
    public void Receive(IGameCommand gameAction);
}
