using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameCommand : IGameCommand
{
    public Token Token { get; private set; }
    public ITokenContainer Container { get; private set; }

    public CommandCategory Category { get; protected set; }

    public void Configure(IDataForCommand data)
    {
        Token = data.Token;
        Container = data.Container;
    }

    public bool IsHighliting()
    {
        return Category == CommandCategory.HighlightOFF
            || Category == CommandCategory.HighlightON;
    }
}

