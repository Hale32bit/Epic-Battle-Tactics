using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TokenMoverScript
{
    [Test]
    public void WhenMoveMethodCelled_ThenTokenReleasedFromOneContainerAndAttachedToOther()
    {
        // Arrange.
        TokenMoverMOCK mover = new TokenMoverMOCK();
        PrepareContainers(
            out Mock<Token> token,
            out Mock<ITokenContainer> firstContainer,
            out Mock<ITokenContainer> secondContainer);

        // Act.
        mover.MoveToken(firstContainer.Object, secondContainer.Object);

        // Assert.
        firstContainer.Verify(x => x.Release(), Times.Once);
        firstContainer.Verify(x => x.Attach(token.Object), Times.Never);
        secondContainer.Verify(x => x.Release(), Times.Never);
        secondContainer.Verify(x => x.Attach(token.Object), Times.Once);
    }

    private static void PrepareContainers(out Mock<Token> token, out Mock<ITokenContainer> firstContainer, out Mock<ITokenContainer> secondContainer)
    {
        token = new Mock<Token>();
        firstContainer = new Mock<ITokenContainer>();
        secondContainer = new Mock<ITokenContainer>();
        firstContainer.Setup(x => x.Release()).Returns(token.Object);
        firstContainer.Setup(x => x.GetToken()).Returns(token.Object);

    }

    private class TokenMoverMOCK : TokenMover
    {
        public TokenMoverMOCK() : base(new Mock<ICommandsBlocker>().Object)
        {
        }

        protected override global::DG.Tweening.Tween GenerateTweenForMoving(ITokenContainer initial, ITokenContainer target)
        {
            return null;
        }
    }

}
