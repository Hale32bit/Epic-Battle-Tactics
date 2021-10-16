using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TestTools;

public class WorldPointerEventDataTest
{
    [Test]
    public void WhenSomeHandlersAdedInData_ThenOriginalIsFirst()
    {
        // Arrange.
        var firstHandler = new GameObject().AddComponent<WorldPointerHandlerSTAB>();
        var secondHandler = new GameObject().AddComponent<WorldPointerHandlerSTAB>();
        var thirdHandler = new GameObject().AddComponent<WorldPointerHandlerSTAB>();
        var Data = new WorldPointerEventData(firstHandler, default);

        // Act.
        Data.AddSource(secondHandler);
        Data.AddSource(thirdHandler);

        // Assert.
        Assert.IsTrue(Data.OriginalSource as WorldPointerHandlerSTAB == firstHandler);
    }

    [Test]
    public void WhenContainerAdedinData_ThenItFounded()
    {
        // Arrange.
        var firstHandler = new GameObject().AddComponent<WorldPointerHandlerSTAB>();
        var primaryContainer = new GameObject().AddComponent<TokenContainerSTAB>();
        var thirdHandler = new GameObject().AddComponent<WorldPointerHandlerSTAB>();
        var data = new WorldPointerEventData(firstHandler, default);

        // Act.
        data.AddSource(primaryContainer);
        data.AddSource(thirdHandler);

        // Assert.
        ITokenContainer foundedContainer = data.GetTokenContainer();
        Assert.IsTrue(foundedContainer as TokenContainerSTAB == primaryContainer);
    }
}

internal class WorldPointerHandlerSTAB : WorldPointerHandler { }