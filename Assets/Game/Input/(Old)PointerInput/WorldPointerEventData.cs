using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public enum PointerEventType { Click, Enter, Exit }

public sealed class WorldPointerEventData : IDataForCommand 
{
    private readonly List<WorldPointerHandler> _sources = new List<WorldPointerHandler>();
    public WorldPointerHandler OriginalSource => _sources[0];
    public PointerEventType EventType { get; private set; }

    Token IDataForCommand.Token => OriginalSource as Token;

    ITokenContainer IDataForCommand.Container => this.GetTokenContainer();

    public WorldPointerEventData(WorldPointerHandler originalSource, PointerEventType type)
    {
        _sources.Add(originalSource);
        EventType = type;
    }

    public void AddSource(WorldPointerHandler source)
    {
        _sources.Add(source);
    }

    public ITokenContainer GetTokenContainer()
    {
        return Find<ITokenContainer>();
    }

    private T Find<T>() where T : class
    {
        return _sources.FirstOrDefault<WorldPointerHandler>(x => x is T) as T;
    }
}


