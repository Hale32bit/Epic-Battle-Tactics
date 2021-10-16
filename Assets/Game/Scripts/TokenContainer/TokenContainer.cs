using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class TokenContainer : WorldPointerHandler, ITokenContainer
{
    private Token Token;

    public void Attach(Token token)
    {
        if (Token != null)
            throw new Exception("Token already exist in this container");

        Token = token;
        SubscribeToChild(token);
    }

    public Token GetToken()
    {
        return Token;
    }

    public void Release()
    {
        if (Token != null)
        {
            UnsubscribeFromChild(Token);
            Token = null;
        }
    }
}
