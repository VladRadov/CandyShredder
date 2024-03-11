using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ManagerScenes : MonoBehaviour
{
    public static ManagerScenes Instance { get; private set; }
    [HideInInspector]
    public UnityEvent<float> LoadingSceneEventHandler = new UnityEvent<float>();

    public void LoadAsyncFromCoroutine(string nameScene) => StartCoroutine(LoadAsync(nameScene));

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    private IEnumerator LoadAsync(string nameScene)
    {
        var operation = SceneManager.LoadSceneAsync(nameScene, LoadSceneMode.Single);

        while (operation.progress <= 1)
        {
            LoadingSceneEventHandler?.Invoke(operation.progress * 100);
            yield return null;
        }
    }
}
