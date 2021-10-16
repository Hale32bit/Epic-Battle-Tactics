using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TokenContainerTests
{
    public class PointerEvents
    {
        [Test]
        public void WhenTokenIsClicked_AndAttachedToContainer_ThenContainerIsClicked()
        {
            // Arrange.
            var token = new GameObject().AddComponent<Token>();
            var container = new GameObject().AddComponent<TokenContainerSTAB>();
            bool eventWasTrigered = false;
            container.Clicked +=
                (x => eventWasTrigered = true);

            // Act.
            container.Attach(token);
            token.OnPointerClick(default);

            // Assert.
            Assert.IsTrue(eventWasTrigered);
        }

        [Test]
        public void WhenTokenIsClicked_AndAttachedToContainerAndRelesed_ThenContainerIsNotClicked()
        {
            // Arrange.
            var token = new GameObject().AddComponent<Token>();
            var container = new GameObject().AddComponent<TokenContainerSTAB>();
            bool eventWasTrigered = false;
            container.Clicked +=
                (x => eventWasTrigered = true);

            // Act.
            container.Attach(token);
            container.Release();
            token.OnPointerClick(default);

            // Assert.
            Assert.IsFalse(eventWasTrigered);
        }


        [Test]
        public void WhenTokenIsPointerEnter_AndAttachedToContainer_ThenContainerIsPointerEnter()
        {
            // Arrange.
            var token = new GameObject().AddComponent<Token>();
            var container = new GameObject().AddComponent<TokenContainerSTAB>();
            bool eventWasTrigered = false;
            container.PointerEnter +=
                (x => eventWasTrigered = true);

            // Act.
            container.Attach(token);
            token.OnPointerEnter(default);

            // Assert.
            Assert.IsTrue(eventWasTrigered);
        }

        [Test]
        public void WhenTokenIsPointerEnter_AndAttachedToContainerAndRelesed_ThenContainerIsNotPointerEnter()
        {
            // Arrange.
            var token = new GameObject().AddComponent<Token>();
            var container = new GameObject().AddComponent<TokenContainerSTAB>();
            bool eventWasTrigered = false;
            container.PointerEnter +=
                (x => eventWasTrigered = true);

            // Act.
            container.Attach(token);
            container.Release();
            token.OnPointerEnter(default);

            // Assert.
            Assert.IsFalse(eventWasTrigered);
        }

        [Test]
        public void WhenTokenIsPointerExit_AndAttachedToContainer_ThenContainerIsPointerExit()
        {
            // Arrange.
            var token = new GameObject().AddComponent<Token>();
            var container = new GameObject().AddComponent<TokenContainerSTAB>();
            bool eventWasTrigered = false;
            container.PointerExit +=
                (x => eventWasTrigered = true);

            // Act.
            container.Attach(token);
            token.OnPointerExit(default);

            // Assert.
            Assert.IsTrue(eventWasTrigered);
        }

        [Test]
        public void WhenTokenIsPointerExit_AndAttachedToContainerAndRelesed_ThenContainerIsNotPointerExit()
        {
            // Arrange.
            var token = new GameObject().AddComponent<Token>();
            var container = new GameObject().AddComponent<TokenContainerSTAB>();
            bool eventWasTrigered = false;
            container.PointerExit +=
                (x => eventWasTrigered = true);

            // Act.
            container.Attach(token);
            container.Release();
            token.OnPointerExit(default);

            // Assert.
            Assert.IsFalse(eventWasTrigered);
        }
    }

    [Test]
    public void WhenTokenAttached_AndReleased_ThenContainerIsEmpty()
    {
        // Arrange.
        var token = new GameObject().AddComponent<Token>();
        var container = new GameObject().AddComponent<TokenContainerSTAB>();

        // Act.
        container.Attach(token);
        container.Release();

        // Assert.
        Assert.IsNull(container.GetToken());
    }
}

internal class TokenContainerSTAB : TokenContainer { }