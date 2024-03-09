using UnityEngine;

public class BulletController
{
    private BulletView _bulletView;
    private Bullet _bullet;

    public BulletController(BulletView bulletView, Bullet bullet)
    {
        _bulletView = bulletView;
        _bullet = bullet;
    }

    public void Initialize()
    {
        _bulletView.Input.InputEventHandler.AddListener((value) => { if(_bullet.IsStopped()) _bullet.UpdateVelocity(value); });
        _bulletView.OnCollisionEventHandler.AddListener(_bullet.UpdateVelocity);
        _bullet.OnUpdateVelocityEventHandler.AddListener(_bulletView.UpdateVelocity);
        _bullet.OnUpdatePositionEventHandler.AddListener(_bulletView.UpdatePosition);
    }
}
