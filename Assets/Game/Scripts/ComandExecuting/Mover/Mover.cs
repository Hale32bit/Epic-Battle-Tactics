using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[DisallowMultipleComponent]
public sealed class Mover : CommandExecutor
{
    private ISelector _selector;

    [Inject]
    private void Construct(ISelector selector)
    {
        _selector = selector;
    }

    protected override void OnCommand(IGameCommand command)
    {
        
    }

    protected override void OnGateLocked()
    {
        
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
