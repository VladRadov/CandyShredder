using UnityEngine;

public class ContainerSaveerPlayerPrefs : MonoBehaviour
{
    [SerializeField] private int _money;

    public static ContainerSaveerPlayerPrefs Instance { get; private set; }
    public SaveerDataInPlayerPrefs SaveerData { get; private set; }

    private void Awake()
    {
        SaveerData = new SaveerDataInPlayerPrefs();

        if (Instance != null)
            Destroy(this.gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }

        SaveerData.Money = _money;
    }
}
