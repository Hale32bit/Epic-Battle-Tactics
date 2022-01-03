using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITokenContainer 
{
    bool IsEmpty { get; }

    Token GetToken();

    void Attach(Token token);
    Token Release();
    Transform Transform { get; }
}
