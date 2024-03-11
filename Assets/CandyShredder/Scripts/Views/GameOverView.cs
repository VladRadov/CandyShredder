using System.Collections.Generic;
using UnityEngine;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private List<AllBonusesView> _allBonusesView;

    public void OnGameOver()
    {
        gameObject.SetActive(true);
    }

    public void ViewCountBonuses(int countMoney, int countCoins)
    {
        var viewCoins = _allBonusesView.Find(view => view.BonusType == TypeBonus.Coin);
        var viewMoney = _allBonusesView.Find(view => view.BonusType == TypeBonus.Money);
        viewCoins.ViewAllCount(countCoins);
        viewMoney.ViewAllCount(countMoney);
    }
}
