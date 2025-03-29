using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float balance = 150f;
    public static float popularity = 0f;
    private float timer = 0f;
    public float incomeInterval = 1f;
    

    public Text balanceText;
    public Text IncomePerSec;
    public Text PopularutyText;

    public float inactivityThreshold = 2f;
    private float inactivityTimer = 0f;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= incomeInterval)
        {
            AddIncome();
            timer = 0f;
        }

        balanceText.text = Mathf.FloorToInt(balance) + "$";
        PopularutyText.text = Mathf.FloorToInt(popularity) + " %";
    }
    void AddIncome()
    {
    float totalIncome = 0f;
    
    factoryMenu[] factories = FindObjectsOfType<factoryMenu>();
    foreach (factoryMenu factory in factories)
    {
        totalIncome += factory.incomePerSecond;
    }

    balance += totalIncome;

        if (balanceText != null)
        {
            balanceText.text = Mathf.FloorToInt(balance) + "$";
        }
    }
}



