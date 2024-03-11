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
    public UnityEvent OnGameOverEvetHandler = new UnityEvent();

    public void UpdatePosition(Vector2 newPosition) => _transform.position = new Vector3(newPosition.x, _transform.position.y, _transform.position.z);

    public void SetTriggerCollider(bool value) => _circleCollider2D.isTrigger = value;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        _startPosition = _transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var candyView = collision.gameObject.GetComponent<CandyView>();
        if (candyView != null)
        {
            OnGameOverEvetHandler?.Invoke();
            OnGameOverEvetHandler.RemoveAllListeners();
        }
    }

    private void OnValidate()
    {
        if (_circleCollider2D == null)
            _circleCollider2D = transform.GetComponent<CircleCollider2D>();
    }

    private void OnDestroy()
    {
        OnGameOverEvetHandler.RemoveAllListeners();
    }
}
