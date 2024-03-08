using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet
{
    private Vector2 _position;

    public UnityEvent<Vector2> OnUpdatePositionEventHandler;

    public Bullet()
    {
        OnUpdatePositionEventHandler = new UnityEvent<Vector2>();
    }

    public void UpdatePosition(Vector2 value)
    {
        _position = value;
        OnUpdatePositionEventHandler?.Invoke(_position);
    }
}
