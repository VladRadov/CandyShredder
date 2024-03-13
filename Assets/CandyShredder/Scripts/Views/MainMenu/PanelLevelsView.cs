using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelLevelsView : MonoBehaviour
{
    [SerializeField] Button _upLevel;
    [SerializeField] Button _downLevel;
    [SerializeField] TextMeshProUGUI _viewLevel;
    [SerializeField] int _maxLevel;

    private void Start()
    {
        UpdateLevel();

        _upLevel.onClick.AddListener(OnUpLevel);
        _downLevel.onClick.AddListener(OnDownLevel);
    }

    private void OnUpLevel()
    {
        if (ContainerSaveerPlayerPrefs.Instance.SaveerData.Level < _maxLevel)
        {
            ContainerSaveerPlayerPrefs.Instance.SaveerData.Level += 1;
            UpdateLevel();
        }
    }

    private void OnDownLevel()
    {
        if (ContainerSaveerPlayerPrefs.Instance.SaveerData.Level != 1)
        {
            ContainerSaveerPlayerPrefs.Instance.SaveerData.Level -= 1;
            UpdateLevel();
        }
    }

    private void UpdateLevel() => _viewLevel.text = ContainerSaveerPlayerPrefs.Instance.SaveerData.Level.ToString();

    private void OnValidate()
    {
        if (_maxLevel <= 0)
            _maxLevel = 1;
    }
}
