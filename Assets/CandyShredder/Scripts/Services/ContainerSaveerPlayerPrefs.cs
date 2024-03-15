using UnityEngine;

public class ContainerSaveerPlayerPrefs : MonoBehaviour
{
    public static ContainerSaveerPlayerPrefs Instance { get; private set; }
    public SaveerDataInPlayerPrefs SaveerData { get; private set; }

    private void Awake()
    {
        SaveerData = new SaveerDataInPlayerPrefs();
        SaveerData.Money = 5006;
        if (Instance != null)
            Destroy(this.gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }
}
