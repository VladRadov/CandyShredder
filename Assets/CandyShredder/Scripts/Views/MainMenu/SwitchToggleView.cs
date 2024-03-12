using UnityEngine;
using UnityEngine.UI;

public class SwitchToggleView : MonoBehaviour
{
    [SerializeField] Sprite _togglwOff;
    [SerializeField] Sprite _togglwOn;
    [SerializeField] Button _toggle;
    [SerializeField] Image _toggleImage;
    [SerializeField] string _keySaveerTool;

    public int LoadToggleState()
    {
        var value = ContainerSaveer.Instance.SaveerData.Load<int>(_keySaveerTool, 1);
        _toggleImage.sprite = value == 1 ? _togglwOn : _togglwOff;

        return value;
    }

    private void Start()
    {
        _toggle.onClick.AddListener(Switch);
    }

    private void OnEnable()
    {
        LoadToggleState();
    }

    private void Switch()
    {
        var currentState = LoadToggleState();
        var nextState = currentState == 1 ? 0 : 1;
        ContainerSaveer.Instance.SaveerData.Save<int>(_keySaveerTool, nextState);
        _toggleImage.sprite = nextState == 1 ? _togglwOn : _togglwOff;
    }

    private void OnValidate()
    {
        if (_toggle == null)
            _toggle = transform.GetComponent<Button>();

        if (_toggleImage == null)
            _toggleImage = transform.GetComponent<Image>();
    }
}