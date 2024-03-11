using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _startGame;
    [SerializeField] private Button _help;
    [SerializeField] private Button _shop;
    [SerializeField] private Button _tools;
    [SerializeField] private LoaderView _loaderView;
    [SerializeField] private ItemView _helpPlayView;
    [SerializeField] private ItemView _toolsView;

    private void Start()
    {
        ManagerScenes.Instance.LoadingSceneEventHandler.AddListener((valuePercent) => { _loaderView.UpdatePercentLoading(valuePercent); });
        _startGame.onClick.AddListener(() => { ManagerScenes.Instance.LoadAsyncFromCoroutine("Game"); });
        _startGame.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            _loaderView.gameObject.SetActive(true);
        });

        _help.onClick.AddListener(_helpPlayView.Show);
        _tools.onClick.AddListener(_toolsView.Show);
    }
}
