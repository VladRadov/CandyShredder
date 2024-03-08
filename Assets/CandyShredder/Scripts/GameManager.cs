using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BlocksCandyView _blocksCandyView;
    [SerializeField] private PlatformView _platformView;
    [SerializeField] private BulletView _bulletView;

    private BlocksCandyController _candyLineStorageController;
    private PlatformController _platformController;
    private BulletController _bulletController;

    private void Start()
    {
        _candyLineStorageController = new BlocksCandyController(_blocksCandyView);
        _candyLineStorageController.Initialize();

        _platformController = new PlatformController(_platformView);
        _platformController.Initialize();

        _bulletController = new BulletController(_bulletView);
        _bulletController.Initialize();
    }
}
