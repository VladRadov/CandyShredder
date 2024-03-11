using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BlocksCandyView _blocksCandyView;
    [SerializeField] private PlatformView _platformView;
    [SerializeField] private BulletView _bulletView;
    [SerializeField] private GameOverView _gameOverView;
    [SerializeField] private List<BonusView> _bonuses;
    [SerializeField] private Transform _canvas;
    [SerializeField] private List<AllBonusesView> _allBonusesView;

    private BlocksCandyController _candyLineStorageController;
    private PlatformController _platformController;
    private BulletController _bulletController;
    private BonusController _bonusController;

    private SaveerDataInPlayerPrefs _saveerDataInPlayerPrefs;

    private Platform _platform;
    private Bullet _bullet;

    private void Start()
    {
        _saveerDataInPlayerPrefs = new SaveerDataInPlayerPrefs();

        _candyLineStorageController = new BlocksCandyController(_blocksCandyView);
        _candyLineStorageController.Initialize();

        _platform = new Platform(_platformView.StartPosition);
        _platformController = new PlatformController(_platformView, _platform);
        _platformController.Initialize();

        _bullet = new Bullet(_bulletView.StartPosition);
        _bulletController = new BulletController(_bulletView, _bullet);
        _bulletController.Initialize();

        _bonusController = new BonusController(_bonuses, _platformView.transform, _canvas);
        _bonusController.SetViewAllBonuses(_allBonusesView);
        _bonusController.SetSaveer(_saveerDataInPlayerPrefs);

        _platform.OnUpdatePositionEventHandler.AddListener(_bullet.UpdatePosition);
        _bulletView.OnTriggerPlatformEventHandler.AddListener(_platformView.SetTriggerCollider);
        _platformView.Input.OnMouseFromPlatformEventHandler.AddListener(_bulletView.Input.OnMouseFromPlatform);
        _platform.OnUpdatePositionEventHandler.AddListener(_bulletView.UpdatePlatformPosition);
        _platformView.OnGameOverEvetHandler.AddListener(() => 
        {
            _gameOverView.ViewCountBonuses(_saveerDataInPlayerPrefs.Load<int>("Money"), _saveerDataInPlayerPrefs.Load<int>("Coins"));
            _gameOverView.OnGameOver();
        });

        foreach (var listCandyLine in _blocksCandyView.ListCandyLine)
            listCandyLine.AddListenerBrokenCandy(_bonusController.OnBrokeCandy);
    }
}