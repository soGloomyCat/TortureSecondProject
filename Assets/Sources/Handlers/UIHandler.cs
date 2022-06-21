using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] Slider _progressBar;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _finalPanel;

    private Coroutine _coroutine;

    public void ChangeValue(int currentValue)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeSliderValue(currentValue));
    }

    public void OpenPanels()
    {
        _progressBar.gameObject.SetActive(false);
        _finalPanel.SetActive(true);
        _button.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _button.gameObject.SetActive(false);
        _finalPanel.SetActive(false);

    }

    private IEnumerator ChangeSliderValue(int currentValue)
    {
        float changeValue;
        float correctValue;
        float maxValue;
        WaitForSeconds waiter;

        changeValue = 0.05f;
        correctValue = currentValue;
        maxValue = correctValue + 0.15f;
        waiter = new WaitForSeconds(0.01f);

        while (_progressBar.value < maxValue)
        {
            _progressBar.value += changeValue;
            yield return waiter;
        }

        while (_progressBar.value > correctValue)
        {
            _progressBar.value -= changeValue;
            yield return waiter;
        }
    }
}
