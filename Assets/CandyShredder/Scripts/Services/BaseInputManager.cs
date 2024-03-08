using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseInputManager<T> : MonoBehaviour
{
    public UnityEvent<T> InputEventHandler;
}
