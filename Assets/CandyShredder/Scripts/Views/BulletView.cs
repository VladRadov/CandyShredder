using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletView : MonoBehaviour
{
    private Transform _transform;
    private Vector2 _startPosition;
    private Vector2 _platformPosition;

    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] private InputMouseBullet _input;
    [SerializeField] ParticleSystem _motionTrail;

    public Vector2 StartPosition => _startPosition;
    public InputMouseBullet Input => _input;
    [HideInInspector]
    public UnityEvent<Vector2> OnCollisionEventHandler = new UnityEvent<Vector2>();
    [HideInInspector]
    public UnityEvent<bool> OnTriggerPlatformEventHandler = new UnityEvent<bool>();

    public void UpdateVelocity(Vector2 target)
    {
        if(target != Vector2.zero)
            _motionTrail.gameObject.SetActive(true);

        _rigidbody2D.velocity = target.normalized * _speed;
    }

    public void UpdatePosition(Vector2 newPosition) => _transform.position = newPosition;

    public void UpdatePlatformPosition(Vector2 newPosition) => _platformPosition = newPosition;

    private void Start()
    {
        _transform = transform;
        _startPosition = transform.position;
        _motionTrail.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var wallView = collision.gameObject.GetComponent<WallView>();
        if (wallView != null)
        {
            OnCollisionEventHandler?.Invoke(collision.relativeVelocity);
            OnTriggerPlatformEventHandler?.Invoke(false);
        }

        var candyView = collision.gameObject.GetComponent<CandyView>();
        if (candyView != null)
        {
            candyView.BrokeCandyEventHandler?.Invoke(candyView.transform);
            OnCollisionEventHandler?.Invoke(_platformPosition - (Vector2)_transform.position);
            OnTriggerPlatformEventHandler?.Invoke(false);
            return;
        }

        var platfromView = collision.gameObject.GetComponent<PlatformView>();
        if (platfromView != null)
        {
            _motionTrail.gameObject.SetActive(false);
            OnCollisionEventHandler?.Invoke(Vector2.zero);
            OnTriggerPlatformEventHandler?.Invoke(true);
        }
    }

    private void OnValidate()
    {
        if (_rigidbody2D == null)
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        OnCollisionEventHandler.RemoveAllListeners();
        OnTriggerPlatformEventHandler.RemoveAllListeners();
    }
}
