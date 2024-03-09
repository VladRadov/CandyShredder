using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformView : MonoBehaviour
{
    private Transform _transform;
    private Vector2 _startPosition;

    [SerializeField] float _intensity;
    [SerializeField] private InputMousePlatform _input;
    [SerializeField] private CircleCollider2D _circleCollider2D;

    public Vector2 StartPosition => _startPosition;
    public InputMousePlatform Input => _input;

    public void UpdatePosition(Vector2 newPosition) => _transform.position = newPosition;

    public void SetTriggerCollider(bool value) => _circleCollider2D.isTrigger = value;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        _startPosition = _transform.position;
    }

    private void OnValidate()
    {
        if (_circleCollider2D == null)
            _circleCollider2D = transform.GetComponent<CircleCollider2D>();
    }
}
