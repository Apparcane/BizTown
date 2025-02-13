using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float money = 0;

    private static float balance = 0f; // Текущий баланс
    //public float incomePerSecond = 10f; // Доход в секунду
    private float timer = 0f;
    public float incomeInterval = 1f;

    public Text balanceText;
    public Text IncomePerSec;



    //public RectTransform uiElement;

    public float inactivityThreshold = 2f;
    private float inactivityTimer = 0f;

   public static float getBalance() 
   {
        return balance;
   }

   public static void setBalance(float value) 
   {
        balance = value;
   }

    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= incomeInterval)
        {
            AddIncome();
            timer = 0f;
        }

        balanceText.text = Mathf.FloorToInt(balance) + " $";



        //IncomePerSec.text = incomePerSecond.ToString("1") + " $/h";
    }
    void AddIncome()
    {
        balance += factoryMenu.incomePerSecond;

        if (balanceText != null)
        {
            balanceText.text = Mathf.FloorToInt(balance) + " $";
        }



    }
}

    
    //void PanelScale(){
       // if(balance >= 10000f){
            //uiElement.sizeDelta = new Vector2(2560, 1080);
        //}
    //}



