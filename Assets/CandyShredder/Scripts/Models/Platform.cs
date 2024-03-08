using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Platform
{
    private float _xPosition;

    public UnityEvent<float> OnUpdatePositionEventHandler;

    public Platform(float xPosition)
    {
        _xPosition = xPosition;
        OnUpdatePositionEventHandler = new UnityEvent<float>();
    }

    public void UpdateXPosition(float value)
    {
        _xPosition = value;
        OnUpdatePositionEventHandler?.Invoke(_xPosition);
    }
}
