using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public TMP_Text currencyText;
    
    [SerializeField] private int startingCurrency;
    private int currency;

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
