using System;

public interface ICellPanel
{
    CellPanelConfig Config { get; }
    bool Visible { get; }
    BattlefieldCell Destination { get; }

    event Action<BattlefieldCell> DestinationChanged;
    event Action<CellPanelConfig> ConfigChanged;
    event Action BecomeUnvisible;
}