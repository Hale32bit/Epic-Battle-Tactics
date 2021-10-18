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
    private Mock<ISelector> _selector;

    [SetUp]
    public void BindInterfaces()
    {
        _gate = new Mock<IGameCommandGate>();
        _selector = new Mock<ISelector>();


        Container.Bind<IGameCommandGate>()
            .FromInstance(_gate.Object)
            .AsSingle();

        Container.Bind<ISelector>()
            .FromInstance(_selector.Object)
            .AsSingle();

        Container.Bind<Highlighter>()
            .FromNewComponentOnNewGameObject()
            .AsTransient();

    }

    [Test]
    public void WhenHighlightObject_ThenHighlightSecondObject_ThenFirstObjectMustHighlitedOFF()
    {
        // Arrange.
        var highliter = Container.Resolve<Highlighter>();
        CommandMocking.PrepareCommand(
            CommandCategory.HighlightON, 
            out Mock<IGameCommand> command1, 
            out Mock<IStatable> highligtable1);

        CommandMocking.PrepareCommand(
            CommandCategory.HighlightON, 
            out Mock<IGameCommand> command2, 
            out Mock<IStatable> highligtable2);

        _selector.Setup(x => x.IsSelected(highligtable1.Object)).Returns(false);
        _selector.Setup(x => x.IsSelected(highligtable2.Object)).Returns(false);

        // Act1.
        _gate.Raise(x => x.CommandReceived += null, command1.Object);

        // Assert.
        highligtable1.Verify(x => x.StartState(StateType.Higlighted));
        highligtable1.VerifyNoOtherCalls();

        // Act2.
        _gate.Raise(x => x.CommandReceived += null, command2.Object);

        // Assert.
        highligtable1.Verify(x => x.EndState(StateType.Higlighted));
        highligtable2.Verify(x => x.StartState(StateType.Higlighted));
    }


    [Test]
    public void WhenReceiveCommandToHighlight_AndObjectSelected_ThenObjectNotHighlighted()
    {
        // Arrange.
        var highliter = Container.Resolve<Highlighter>();
        CommandMocking.PrepareCommand(
            CommandCategory.HighlightON, 
            out Mock<IGameCommand> command, 
            out Mock<IStatable> highligtable);
        _selector.Setup(x => x.IsSelected(highligtable.Object)).Returns(true);

        // Act.
        _gate.Raise(x => x.CommandReceived += null, command.Object);

        // Assert.
        highligtable.VerifyNoOtherCalls();
    }


}

