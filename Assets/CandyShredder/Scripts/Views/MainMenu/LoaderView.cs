using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoaderView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _viewPercent;

    public void UpdatePercentLoading(float valuePercent) => _viewPercent.text = valuePercent.ToString() + "%";
}
