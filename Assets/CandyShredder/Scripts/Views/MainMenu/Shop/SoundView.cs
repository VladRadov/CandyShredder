using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundView : ItemShopView
{
    [Header("UI")]
    [SerializeField] private Sprite _noPurchased;
    [SerializeField] private Sprite _purchased;
    [SerializeField] private Sound _sound;
    [SerializeField] private Button _entrySound;
    [SerializeField] private Button _playCheck;

    public override void OnBuy()
    {
        if (Price > ContainerSaveerPlayerPrefs.Instance.SaveerData.Money)
            return;

        SetSpriteButton(_purchased);
        SetEnableButtonBuy(true);

        if (ContainerSaveerPlayerPrefs.Instance.SaveerData.PurchasedSounds != "Standart")
            ContainerSaveerPlayerPrefs.Instance.SaveerData.PurchasedSounds += "," + _sound.Name;
        else
            ContainerSaveerPlayerPrefs.Instance.SaveerData.PurchasedSounds = _sound.Name;

        ContainerSaveerPlayerPrefs.Instance.SaveerData.CurrentSound = _sound.Name;
        ContainerSaveerPlayerPrefs.Instance.SaveerData.Money -= Price;
        OnPurchasedEventHandler?.Invoke();

        _entrySound.onClick.AddListener(() => { ContainerSaveerPlayerPrefs.Instance.SaveerData.CurrentSound = _sound.Name; });
    }

    protected override void Start()
    {
        _playCheck.onClick.AddListener(() => { AudioManager.Instance.PlayPartSound(_sound.Name); });

        if (ContainerSaveerPlayerPrefs.Instance.SaveerData.PurchasedSounds.Contains(_sound.Name))
        {
            _entrySound.enabled = true;
            SetSpriteButton(_purchased);
            SetEnableButtonBuy(false);
            _entrySound.onClick.AddListener(() => { ContainerSaveerPlayerPrefs.Instance.SaveerData.CurrentSound = _sound.Name; });
        }
        else
            _entrySound.enabled = false;

        base.Start();
    }

    private void OnValidate()
    {
        if (_entrySound == null)
            _entrySound = GetComponent<Button>();
    }
}
