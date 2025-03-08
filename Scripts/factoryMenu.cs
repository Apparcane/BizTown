using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class factoryMenu : MonoBehaviour
{
    private bool isFactoryActive = false;
    public GameObject Buton;
    public GameObject BuyButton; // Кнопка покупки фабрики
    private float wiewTime = 15f;

    public static float boxBalance = 0f;
    [SerializeField] public static float incomePerSecond = 0f; // Доход обнулён до покупки
    public int factoryLvl = 0;

    public Text IncomePerSec;
    public Text Lvl;
    public Text Upgrade;

    public float inactivityThreshold = 5f;
    private float inactivityTimer = 0f;
    public float inactivityThreshold1 = 2f;
    private float inactivityTimer1 = 0f;

    public static float upgradePrice = 250f;
    public float priceMultiplier = 1.7f;
    public float upgradeMultiplier = 2f;
    public static float factoryPrice = 500f; // Цена покупки фабрики

    public GameObject errorText;
    [SerializeField] Text UpgradeBTN;

    private void Start()
    {
        Buton.SetActive(false);
        BuyButton.SetActive(true); // Показываем кнопку покупки
        errorText.SetActive(false);
    }

    private void Update()
    {
        IncomePerSec.text = Mathf.FloorToInt(incomePerSecond) + " $/s";
        inactivityTimer += Time.deltaTime;

        if (inactivityTimer >= inactivityThreshold)
        {
            Buton.SetActive(false);
        }

        inactivityTimer1 += Time.deltaTime;
        if (inactivityTimer1 >= inactivityThreshold1)
        {
            errorText.SetActive(false);
        }
    }

    public void OuseUp()
    {
        Buton.SetActive(true);       
    }

    public void BuyFactory()
    {
        if (GameManager.getBalance() >= factoryPrice)
        {
            GameManager.setBalance(GameManager.getBalance() - factoryPrice);
            isFactoryActive = true;
            incomePerSecond = 5f; // Начальный доход после покупки
            BuyButton.SetActive(false); // Убираем кнопку покупки
            UpgradeBTN.text = "Upgrade";
        }
        else
        {
            errorText.SetActive(true);
            Debug.Log("Не хватает денег на фабрику");
        }
    }

    public void UpgradeFactory()
    {
        if (isFactoryActive)
        {
            if (GameManager.getBalance() >= upgradePrice)
            {
                GameManager.setBalance(GameManager.getBalance() - upgradePrice);
                incomePerSecond *= priceMultiplier;
                upgradePrice *= upgradeMultiplier;
                factoryLvl++;
                Lvl.text = Mathf.FloorToInt(factoryLvl) + " Lvl";

            }
            else
            {
                errorText.SetActive(true);
                Debug.Log("Ты бедность");
            }
        }
    }
}
