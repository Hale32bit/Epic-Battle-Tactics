using System.Collections;
using System;
using System.Collections.Generic;

namespace GameStates
{
    public interface IGameStatePublisher
    {
        event Action Started;
        event Action Stoped;
    }
}
