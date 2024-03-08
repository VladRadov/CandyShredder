using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    private BulletView _bulletView;
    private Bullet _bullet;

    public BulletController(BulletView bulletView)
    {
        _bulletView = bulletView;
        _bullet = new Bullet();
    }

    public void Initialize()
    {
        _bulletView.SubscribeOnInputs(_bullet.UpdatePosition);
        _bullet.OnUpdatePositionEventHandler.AddListener(_bulletView.UpdatePosition);
    }
}
