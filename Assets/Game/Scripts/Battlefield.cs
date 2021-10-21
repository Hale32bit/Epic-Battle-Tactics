using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Battlefield : WorldPointerHandler
{
    public const int Width = 5;
    public const int Lenght = 5;

    [SerializeField] private BattlefieldCell _cellPrefab;

    private readonly List<BattlefieldCell> _cells = new List<BattlefieldCell>();

    void Start()
    {
        for (int x = 0; x < Width; x++)
            for (int z = 0; z < Lenght; z++)
                InstatiateCell(x, z);
    }

    private void InstatiateCell(int x, int z)
    {
        var cell = GameObject.Instantiate(_cellPrefab, this.gameObject.transform);
        
        Vector3 leftForwardCornerOffset = (Vector3.forward * (float)Lenght * BattlefieldCell.PhisicalLenght +
            Vector3.left * (float)Width * BattlefieldCell.PhisicalWidth) / 2f;

        cell.transform.position = 
            leftForwardCornerOffset +
            Vector3.right * BattlefieldCell.PhisicalWidth * (float)x +
            Vector3.back * BattlefieldCell.PhisicalLenght * (float)z;

        this.SubscribeToChild(cell);
        _cells.Add(cell);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
