using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ListCandyLineView : MonoBehaviour
{
    private Transform _transform;

    [SerializeField] private List<CandyLineView> _listCandyLine;

    public List<CandyLineView> CandyLines => _listCandyLine;

    private void Awake()
    {
        _transform = transform;
    }

    public void AddListenerBrokenCandy(UnityAction<Transform> action)
    {
        foreach (var listCandyLine in _listCandyLine)
            listCandyLine.AddListenerBrokenCandy(action);
    }

    private void OnValidate()
    {
        if (_listCandyLine == null || _listCandyLine.Count == 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var candyLineView = transform.GetChild(i)?.GetComponent<CandyLineView>();
                if (candyLineView != null)
                    _listCandyLine.Add(candyLineView);
            }
        }
    }
}
