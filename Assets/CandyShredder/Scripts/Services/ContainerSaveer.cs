using UnityEngine;

public class ContainerSaveer : MonoBehaviour
{
    public static ContainerSaveer Instance { get; private set; }
    public SaveerData SaveerData { get; private set; }

    private void Awake()
    {
        SaveerData = new SaveerDataInPlayerPrefs();

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }
}
