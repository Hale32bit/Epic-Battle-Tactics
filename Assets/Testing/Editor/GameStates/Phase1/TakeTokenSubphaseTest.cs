using Zenject;
using NUnit.Framework;
using GameStates;
using GameStates.Phase1Space;
using GameCommands;
using Moq;

[TestFixture]
public class TakeTokenSubphaseTest 
{    
    [Test]
    public void WhenSubphaseTakeCommandTake_ThenItTakeFromTakerAndChangeSubphaseToPlace()
    {
        // Arrange.
        var taker = new Mock<INewTokenTaker>();
        var parent = new Mock<IStateParent>();
        GameState takeTokenSubphase = PrepareTakeTokenPhase(taker, parent);
        var command = PrepareTakeCommand();

        // Act.
        takeTokenSubphase.ExecuteCommand(command.Object);

        // Assert.
        VerifyThatPhaseWasSwitchedCorrect(parent);
        taker.Verify(x => x.Take());
    }

    private static void VerifyThatPhaseWasSwitchedCorrect(Mock<IStateParent> parent)
    {
        parent.Verify(x => x.SwitchToState<PlaceTokenSubphase>());
    }

    private static Mock<IGameCommand> PrepareTakeCommand()
    {
        var command = new Mock<IGameCommand>();
        command.Setup(x => x.Category).Returns(CommandCategory.Take);
        return command;
    }

    private static GameState PrepareTakeTokenPhase(Mock<INewTokenTaker> taker, Mock<IStateParent> parent)
    {
        GameStates.GameState takeTokenSubphase = new TakeTokenSubphase(default, taker.Object);
        takeTokenSubphase.Initialize(parent.Object);
        return takeTokenSubphase;
    }

}