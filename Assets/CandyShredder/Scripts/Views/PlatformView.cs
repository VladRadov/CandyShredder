using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformView : MonoBehaviour
{
    private Transform _transform;
    private float _startPositionX;

    [SerializeField] float _intensity;
    [SerializeField] private List<BaseInputManager<float>> _inputs;

    public float StartPositionX => _startPositionX;

    public void SubscribeOnInputs(UnityAction<float> action)
    {
        foreach (var input in _inputs)
            input.InputEventHandler.AddListener(action);
    }

    public void UpdatePosition(float xPosition) => _transform.position = new Vector2(xPosition, _transform.position.y);

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        _startPositionX = _transform.position.x;
    }
}
