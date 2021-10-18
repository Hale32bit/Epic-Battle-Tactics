using System.Security.Cryptography.X509Certificates;
using Zenject;
using NUnit.Framework;
using Moq;

[TestFixture]
public class SelectorTest : ZenjectUnitTestFixture
{

    Mock<IGameCommandGate> _gate;

    [SetUp]
    public void Initialize()
    {
        _gate = new Mock<IGameCommandGate>();

        Container.Bind<IGameCommandGate>()
        .FromInstance(_gate.Object)
        .AsSingle();

        Container.Bind<Selector>()
        .FromNewComponentOnNewGameObject()
        .AsTransient();
    }

    [Test]
    public void WhenSelectObject_AndSelectAnotherObject_FirstObjectDeselected()
    {
        //Arrange.
        var selector = Container.Resolve<Selector>();
        CommandMocking.PrepareCommand(
            CommandCategory.Targeting, 
            out Mock<IGameCommand> command1, 
            out Mock<IStatable> selectable1);
                    CommandMocking.PrepareCommand(
            CommandCategory.Targeting, 
            out Mock<IGameCommand> command2, 
            out Mock<IStatable> selectable2);

        //Act.
        _gate.Raise(x => x.CommandReceived += null, command1.Object);

        //Assert.
        selectable1.Verify(x => x.StartState(StateType.Selected));
        selectable1.VerifyNoOtherCalls();

        //Act.
        _gate.Raise(x => x.CommandReceived += null, command2.Object);

        //Assert.
        selectable1.Verify(x => x.EndState(StateType.Selected));
        selectable1.VerifyNoOtherCalls();
        selectable2.Verify(x => x.StartState(StateType.Selected));
    }

}