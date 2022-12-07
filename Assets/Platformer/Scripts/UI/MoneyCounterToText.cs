using TMPro;
using UnityEngine;

public class MoneyCounterToText : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] IntCounter moneyCounter;

    private void Start()
    {
        moneyCounter.onValueChanged.AddListener(UpdateText);

        UpdateText();
    }

    private void OnDestroy()
    {
        moneyCounter.onValueChanged.RemoveListener(UpdateText);
    }

    private void UpdateText()
    {
        text.text = $"Count: {moneyCounter.Count}";
    }
}