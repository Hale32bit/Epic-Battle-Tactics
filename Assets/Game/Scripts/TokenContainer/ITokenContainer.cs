using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITokenContainer 
{
    Token GetToken();

    void Attach(Token token);
    void Release();

}
