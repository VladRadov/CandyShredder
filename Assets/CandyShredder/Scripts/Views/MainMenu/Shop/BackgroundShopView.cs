using UnityEngine;
using UnityEngine.UI;

public class BackgroundShopView : ItemShopView
{
    [Header("UI")]
    [SerializeField] private Sprite _noPurchased;
    [SerializeField] private Sprite _purchased;
    [SerializeField] private BackgroundGame _backgroundGame;
    [SerializeField] private Button _entryBackground;

    public override void OnBuy()
    {
        if (Price > ContainerSaveerPlayerPrefs.Instance.SaveerData.Money)
            return;

        SetSpriteButton(_purchased);
        SetEnableButtonBuy(true);

        if (ContainerSaveerPlayerPrefs.Instance.SaveerData.PurchasedBackgrounds != "base")
            ContainerSaveerPlayerPrefs.Instance.SaveerData.PurchasedBackgrounds += "," + _backgroundGame.Name;
        else
            ContainerSaveerPlayerPrefs.Instance.SaveerData.PurchasedBackgrounds = _backgroundGame.Name;

        ContainerSaveerPlayerPrefs.Instance.SaveerData.CurrentBackground = _backgroundGame.Name;
        ContainerSaveerPlayerPrefs.Instance.SaveerData.Money -= Price;
        OnPurchasedEventHandler?.Invoke();

        _entryBackground.onClick.AddListener(() => { ContainerSaveerPlayerPrefs.Instance.SaveerData.CurrentBackground = _backgroundGame.Name; });
    }

    protected override void Start()
    {
        if (ContainerSaveerPlayerPrefs.Instance.SaveerData.PurchasedBackgrounds.Contains(_backgroundGame.Name))
        {
            _entryBackground.enabled = true;
            SetSpriteButton(_purchased);
            SetEnableButtonBuy(false);
            _entryBackground.onClick.AddListener(() => { ContainerSaveerPlayerPrefs.Instance.SaveerData.CurrentBackground = _backgroundGame.Name; });
        }
        else
            _entryBackground.enabled = false;

        base.Start();
    }

    private void OnValidate()
    {
        if (_entryBackground == null)
            _entryBackground = GetComponent<Button>();
    }
}
