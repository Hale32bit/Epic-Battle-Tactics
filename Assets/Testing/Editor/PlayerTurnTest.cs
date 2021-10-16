using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTurnTest
{


    [Test]
    public void WhenPlayerTurnCreated_ThenPlayerOneBecomesCurrent()
    {
        // Arrange.
        var player1 = new HotSeatPlayer();
        var player2 = new HotSeatPlayer();

        // Act.
        var turn = new PlayerTurn(player1, player2);

        // Assert.
        Assert.IsTrue(turn.CurrentPlayer == player1);
    }

        
    [Test]
    public void WhenBecomesNextTurn_ThenSecondPlayerBecomeCurrent()
    {
        // Arrange.
        var player1 = new HotSeatPlayer();
        var player2 = new HotSeatPlayer();
        var turn = new PlayerTurn(player1, player2);

        // Act.
        turn.NextTurn();

        // Assert.
        Assert.IsTrue(turn.CurrentPlayer == player2);
    }

    [Test]
    public void WhenBecomesNextTurnTwice_ThenFirstPlayerBecomeCurrent()
    {
        // Arrange.
        var player1 = new HotSeatPlayer();
        var player2 = new HotSeatPlayer();
        var turn = new PlayerTurn(player1, player2);

        // Act.
        turn.NextTurn();
        turn.NextTurn();

        // Assert.
        Assert.IsTrue(turn.CurrentPlayer == player1);
    }
}
