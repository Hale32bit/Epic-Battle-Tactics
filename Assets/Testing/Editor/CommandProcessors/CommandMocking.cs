using System.Collections;
using System.Collections.Generic;
using Moq;
using UnityEngine;

public static class CommandMocking 
{
    public static void PrepareCommand(CommandCategory category, out Mock<IGameCommand> command, out Mock<IStatable> highligtable)
    {
        command = new Mock<IGameCommand>();
        var container = new Mock<ITokenContainer>();
        highligtable = container.As<IStatable>();
        command.Setup(x => x.Category).Returns(category);
        command.Setup(x => x.Container).Returns(container.Object);
        command.Setup(x => x.IsHighliting()).Returns(true);
    }


}
