using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameCommandsGateTest
{
    [Test]
    public void IfGateLocked_CommandsNotReceived()
    {
        // Arrange.
        var gate = new GameCommandsGate();
        IGameCommandGate igate = gate;
        ICommandsBlocker blocker = gate;
        IGameCommandClient client = gate;
        bool isCommandReceived = false;
        igate.CommandReceived += (a => isCommandReceived = true);


        // Act.
        blocker.Lock();
        client.Receive(new GameCommandSTAB());

        // Assert.
        Assert.IsFalse(isCommandReceived);
    }


    [Test]
    public void IfGateUnlocked_CommandsReceived()
    {
        // Arrange.
        var gate = new GameCommandsGate();
        IGameCommandGate igate = gate;
        ICommandsBlocker blocker = gate;
        IGameCommandClient client = gate;
        bool isCommandReceived = false;
        igate.CommandReceived += (a => isCommandReceived = true);


        // Act.
        blocker.Lock();
        blocker.Unlock();
        client.Receive(new GameCommandSTAB());

        // Assert.
        Assert.IsTrue(isCommandReceived);
    }


    [Test]
    public void WhenGateBocomesLocked_ThenWorksEventLocked()
    {
        // Arrange.
        var gate = new GameCommandsGate();
        bool isEventWorks = false;
        gate.BecomeLocked += (() => isEventWorks = true);

        // Act.
        (gate as ICommandsBlocker).Lock();

        // Assert.
        Assert.IsTrue(isEventWorks);
    }
}

public class GameCommandSTAB :GameCommand
{ }