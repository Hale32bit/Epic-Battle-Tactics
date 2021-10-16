using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAvaliableActionsClient 
{
    void Receive(AvaliableActionsList actions);
}
