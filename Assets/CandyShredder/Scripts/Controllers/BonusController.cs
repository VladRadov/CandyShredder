using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController
{
    private List<BonusView> _bonuses;
    private Transform _parent;
    private Transform _platform;
    private List<AllBonusesView> _allBonusesView;
    private SaveerDataInPlayerPrefs _saveerDataInPlayerPrefs;

    public BonusController(List<BonusView> bonuses, Transform platform, Transform parent = null)
    {
        _bonuses = bonuses;
        _platform = platform;
        _parent = parent;
    }

    public void SetViewAllBonuses(List<AllBonusesView> allBonusesView) => 
        _allBonusesView = allBonusesView;

    public void SetSaveer(SaveerDataInPlayerPrefs saveerDataInPlayerPrefs) => 
        _saveerDataInPlayerPrefs = saveerDataInPlayerPrefs;

    public void OnBrokeCandy(Transform candy)
    {
        var indexRandom = Random.Range(0, _bonuses.Count);
        var bonusView = PoolObjects<BonusView>.GetObject(_bonuses[indexRandom], _parent);

        FindUIForTypeBonus(bonusView);
        bonusView.ReceivingBonusEventHandler.AddListener(bonusView.ReceivingBonus);
        bonusView.transform.position = candy.position;
        bonusView.View();
        bonusView.Move(_platform);
    }

    private void FindUIForTypeBonus(BonusView bonus)
    {
        var uiForViewAllBonus = _allBonusesView.Find(bonusView => bonusView.BonusType == bonus.Type);
        bonus.ReceivingBonusEventHandler.RemoveAllListeners();
        bonus.ReceivingBonusEventHandler.AddListener(() => { uiForViewAllBonus.UpdateCount(1); });
        bonus.ReceivingBonusEventHandler.AddListener(() =>
        {
            _saveerDataInPlayerPrefs.Save<int>(bonus.Type == TypeBonus.Money ? "Money" : "Coins", uiForViewAllBonus.CountBonus);
        });
    }
}
