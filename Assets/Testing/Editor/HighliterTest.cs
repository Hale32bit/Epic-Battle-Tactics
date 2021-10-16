using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;
using Moq;
using NUnit.Framework.Constraints;
using System.Windows.Input;

[TestFixture]
public class HighliterTest  : ZenjectUnitTestFixture
{
    private Mock<IGameCommandGate> _gate;

    [SetUp]
    public void BindInterfaces()
    {
        _gate = new Mock<IGameCommandGate>();
        
        Container.BindInterfacesAndSelfTo<IGameCommandGate>()
            .FromInstance(_gate.Object)
            .AsSingle();

        Container.Bind<Highliter>()
            .FromNewComponentOnNewGameObject()
            .AsTransient();
    }

    [Test]
    public void WhenHighlightObject_ThenHighlightSecondObject_ThenFirstObjectMustHighlitedOFF()
    {
        // Arrange.
        var highliter = Container.Resolve<Highliter>();
        PrepareHighlightONCommand(out Mock<IGameCommand> command1, out Mock<IHiglitable> highligtable1);
        PrepareHighlightONCommand(out Mock<IGameCommand> command2, out Mock<IHiglitable> highligtable2);

        // Act1.
        _gate.Raise(x => x.CommandReceived += null, command1.Object);

        // Assert.
        highligtable1.Verify(x => x.HiglightON());
        highligtable1.VerifyNoOtherCalls();

        // Act2.
        _gate.Raise(x => x.CommandReceived += null, command2.Object);

        // Assert.
        highligtable1.Verify(x => x.HiglightOFF());
        highligtable2.Verify(x => x.HiglightON());
    }

    private static void PrepareHighlightONCommand(out Mock<IGameCommand> command, out Mock<IHiglitable> highligtable)
    {
        command = new Mock<IGameCommand>();
        var container = new Mock<ITokenContainer>();
        highligtable = container.As<IHiglitable>();
        command.Setup(x => x.Category).Returns(CommandCategory.HighlightON);
        command.Setup(x => x.Container).Returns(container.Object);
        command.Setup(x => x.IsHiliting()).Returns(true);
    }
}

