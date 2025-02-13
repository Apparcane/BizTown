using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    public Text incomeText;
    public Text priceText;
    public Text balanceText;
    public Button upgradeButton;
    
    private float income = 10f; // Начальный доход
    private float upgradePrice = 50f; // Начальная цена прокачки
    private float balance = 100f; // Баланс игрока
    private float multiplier = 1.7f; // Множитель увеличения

    void Start()
    {
        UpdateUI();
        upgradeButton.onClick.AddListener(Upgrade);
    }

    void Upgrade()
    {
        if (balance >= upgradePrice)
        {
            balance -= upgradePrice;
            income *= multiplier;
            upgradePrice *= multiplier;
            UpdateUI();
        }
        else
        {
            Debug.Log("Недостаточно средств для улучшения!");
        }
    }

    void UpdateUI()
    {
        incomeText.text = "Доход: " + income.ToString("F2");
        priceText.text = "Цена улучшения: " + upgradePrice.ToString("F2");
        balanceText.text = "Баланс: " + balance.ToString("F2");
    }
}