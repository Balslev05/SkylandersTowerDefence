using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] private TMP_Text currencyText;
    
    [SerializeField] private int startingCurrency;
    public int currency;

    private void Start()
    {
        currency = startingCurrency;
        UpdateText();
    }

    public void GetMoney(int amount)
    {
        currency += amount;
        UpdateText();
    }

    public void LoseMoney(int amount)
    {
        currency -= amount;
        UpdateText();
    }

    private void UpdateText()
    {
        currencyText.text = $"Currency: {currency.ToString()}";
    }
}
