using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class WorldPointerInput : ITickable 
{
    public event Action LeftClicked;
    public event Action RightClicked;

    public Vector2 MousePosition { get; private set; }

    private bool _lastLeftButtonValue = false;
    private bool _lastRightButtonValue = false;


    void ITickable.Tick()
    {
        ReadNewValues(out bool currentLeftButtonValue, out bool currentRightButtonValue);
        CheckLeftClick(currentLeftButtonValue);
        CheckRightClick(currentRightButtonValue);

        _lastLeftButtonValue = currentLeftButtonValue;
        _lastRightButtonValue = currentRightButtonValue;
    }

    private void CheckRightClick(bool currentRightButtonValue)
    {
        if (currentRightButtonValue == false &&
            _lastRightButtonValue == true)
            RightClicked?.Invoke();
    }

    private void CheckLeftClick(bool currentLeftButtonValue)
    {
        if (currentLeftButtonValue == false &&
            _lastLeftButtonValue == true)
            LeftClicked?.Invoke();
    }

    private void ReadNewValues(out bool currentLeftButtonValue, out bool currentRightButtonValue)
    {
        MousePosition = Mouse.current.position.ReadValue();
        currentLeftButtonValue = Mouse.current.leftButton.isPressed;
        currentRightButtonValue = Mouse.current.rightButton.isPressed;
    }
}
