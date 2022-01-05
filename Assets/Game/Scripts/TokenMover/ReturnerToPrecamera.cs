using System.Collections;
using System.Collections.Generic;

public sealed class ReturnerToPrecamera : TokenMoverToPrecamera, IReturnerToPrecamera
{
    private ICellPanel _cellPanel;

    public ReturnerToPrecamera(
        ICommandsBlocker commandBlocker, 
        IPreCameraTokenContainer preCamera, 
        ICellPanel cellPanel) 
        : base(commandBlocker, preCamera)
    {
        _cellPanel = cellPanel;
    }

    public void Return()
    {
        BindWithPreCamera(_cellPanel.Destination);
        base.MoveToken(_cellPanel.Destination, _preCamera);
    }
}
