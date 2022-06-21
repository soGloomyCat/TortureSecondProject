using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExtinguishedObjectAnalyzer : MonoBehaviour
{
    private int _extinguishedTreesCount;

    public event UnityAction<int> CountChanged;
    public event UnityAction GameOver;

    public void ChangeCount()
    {
        _extinguishedTreesCount++;
        CountChanged?.Invoke(_extinguishedTreesCount);

        if (_extinguishedTreesCount == 5)
            GameOver?.Invoke();
    }

    private void OnEnable()
    {
        _extinguishedTreesCount = 0;
    }
}
