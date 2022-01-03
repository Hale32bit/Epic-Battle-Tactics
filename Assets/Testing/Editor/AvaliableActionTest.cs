using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class AvaliableActionTest
{
    [Test]
    public void WhenCommandGeneratedWithData_ItConfiguredWithThatData()
    {
        // Arrange.
        var token = new GameObject().AddComponent<Token>();
        AvaliableAction avaliable =  new AvaliableActionSTAB();

        // Act.
        avaliable.TryGenerateCommand(
            new WorldPointerEventData(token, default),
            out IGameCommand command);

        //Substitute
        // Assert.
        Assert.IsTrue(command.Token == token);
    }

    private class AvaliableActionSTAB : AvaliableAction
    {
        public AvaliableActionSTAB()
        {
            Command = new GameCommands.SpawnOnBattlefield(); 
        }

        protected override bool PredicateForData(IDataForCommand data)
        {
            return true;
        }

        protected override bool PredicateForObject(GameObject obj)
        {
            return true;
        }
    }
}

