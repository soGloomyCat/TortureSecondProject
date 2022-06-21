using System.Collections.Generic;
using UnityEngine;

public class EventsHandler : MonoBehaviour
{
    [SerializeField] private List<IgniteObject> _igniteObjects;
    [SerializeField] private ExtinguishedObjectAnalyzer _analizer;
    [SerializeField] private UIHandler _uIController;

    private void OnEnable()
    {
        foreach (var igniteObject in _igniteObjects)
        {
            igniteObject.Extinguished += _analizer.ChangeCount;
        }

        _analizer.CountChanged += _uIController.ChangeValue;
        _analizer.GameOver += _uIController.OpenPanels;
    }

    private void OnDisable()
    {
        foreach (var igniteObject in _igniteObjects)
        {
            igniteObject.Extinguished -= _analizer.ChangeCount;
        }

        _analizer.CountChanged -= _uIController.ChangeValue;
        _analizer.GameOver -= _uIController.OpenPanels;
    }
}
