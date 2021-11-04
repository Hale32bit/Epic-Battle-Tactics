using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class NeedsGamePhase : Attribute
{
    public Type Requirement { get; private set; }

    public NeedsGamePhase(Type requirement)
    {
        if (requirement.GetInterface("IGameState") == null)
            throw new Exception("Type Must Be IGameState");

        Requirement = requirement;
    }
}