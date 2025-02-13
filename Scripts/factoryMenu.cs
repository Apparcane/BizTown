using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class factoryMenu : MonoBehaviour
{



    public GameObject Buton;
    private float wiewTime = 15f;

    public static float boxBalance = 0f; // Количество товара
    [SerializeField]public static float incomePerSecond = 5f; // Товар пасивно в секунду
    public float factoryLvl = 1f;

    public Text IncomePerSec;
      //public Button upgradeButton;
      public Text Lvl;

    public float inactivityThreshold = 5f;
    private float inactivityTimer = 0f;

    public float inactivityThreshold1 = 2f;
    private float inactivityTimer1 = 0f;

    public static float upgradePrice = 250f; // Начальная цена прокачки
    public float priceMultiplier = 1.7f; // Множитель увеличения
    public float upgradeMultiplier = 2f;

    public GameObject errorText;

    

    private void OnMouseUpAsButton()
    {
        if (Buton != null)
        {
            Buton.SetActive(true);
        }


    }

    private void Start()
    {
        Buton.SetActive(false);

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

    void OnMouseOver()
    {
        ResetTimer();
    }

    void OnTriggerEnter(Collider other)
    {
        ResetTimer();
    }

    void OnTriggerStay(Collider other)
    {
        ResetTimer();
    }

    void ResetTimer()
    {
        inactivityTimer = 0f;
        Buton.SetActive(true);
    }

    public void UpgradeFactoy()
    {         
        if (GameManager.getBalance() >= upgradePrice)
        {
            GameManager.setBalance(GameManager.getBalance() - upgradePrice);
            incomePerSecond *= priceMultiplier;
            upgradePrice *= upgradeMultiplier;
            factoryLvl ++;
        }

        else{
            errorText.SetActive(true);
            Debug.Log("Ты бедность");
        }

        Lvl.text = Mathf.FloorToInt(factoryLvl) + " Lvl";
    }
}