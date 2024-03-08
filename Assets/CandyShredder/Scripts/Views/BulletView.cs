using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletView : MonoBehaviour
{
    private Transform _transform;

    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] private List<BaseInputManager<Vector2>> _inputs;

    public void UpdatePosition(Vector2 target) => _rigidbody2D.velocity = target.normalized * _speed * Time.deltaTime;

    public void SubscribeOnInputs(UnityAction<Vector2> action)
    {
        foreach (var input in _inputs)
            input.InputEventHandler.AddListener(action);
    }

    private void Start()
    {
        _transform = transform;
    }

    private void OnValidate()
    {
        if (_rigidbody2D == null)
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
    }
}
