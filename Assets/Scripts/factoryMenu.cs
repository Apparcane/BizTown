using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class factoryMenu : MonoBehaviour
{

    public bool isFactoryMy;

    public GameObject Buton;
    public GameObject dollar;
    public GameObject errorText;
    public GameObject UpgradeMenu;
    public GameObject BuyButton;
    private float wiewTime = 15f;

    public float incomePerSecond = 0f;
    public float factoryLvl = 1f;

    public Text IncomePerSec;
    public Text Lvl;
    public Text BuyPrice;
    public Text UpgradePrice;


    public float inactivityThreshold = 5f;
    private float inactivityTimer = 0f;

    public float upgradePrice = 250f;
    public float buyPrice = 150f;

       

    

    private void OnMouseUpAsButton()
    {

        inactivityTimer = 0f;

         Debug.Log("Клик по фабрике: " + gameObject.name);

        if (Buton != null)
        {
            Buton.SetActive(true);
        }

        if(!isFactoryMy) {
            BuyButton.SetActive(true);
        }

        if(isFactoryMy) {
            UpgradeMenu.SetActive(true);
        }

        ResetTimer();


    }

    private void Start()
    {
        Buton.SetActive(false);

        errorText.SetActive(false);

        isFactoryMy = false;

        UpgradeMenu.SetActive(false);
        BuyButton.SetActive(true);

         dollar.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    private void Update()
    {
        IncomePerSec.text = Mathf.FloorToInt(incomePerSecond) + " $/s";
        BuyPrice.text = Mathf.FloorToInt(buyPrice) + " $";
        UpgradePrice.text = Mathf.FloorToInt(upgradePrice) + " $";

        inactivityTimer += Time.deltaTime;

        if (inactivityTimer >= inactivityThreshold)
        {
            Buton.SetActive(false);
            errorText.SetActive(false);
        }

        Lvl.text = Mathf.FloorToInt(factoryLvl) + " Lvl";


    }

    void OnTriggerEnter(Collider other)
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
        if(isFactoryMy){
           if (GameManager.balance >= upgradePrice)
            {
            GameManager.balance -= upgradePrice;
            incomePerSecond *= 1.7f;
            upgradePrice *= 2f;
            factoryLvl ++;
            ResetTimer();
                GameObject.Find("SoundController").GetComponent<SoundController>().PlayLevelUp();
            }
        
        else{
            errorText.SetActive(true);
            } 
        }
        

    }


    public void BuyFactory(){
        Debug.Log("Покупка фабрики вызвана");
        if (GameManager.balance >= buyPrice)
            {
            GameManager.balance -= buyPrice;
            incomePerSecond += 5;
            isFactoryMy = true;
            UpgradeMenu.SetActive(true);
            BuyButton.SetActive(false);
            dollar.GetComponent<MeshRenderer>().material.color = Color.green;
            ResetTimer();
            GameObject.Find("SoundController").GetComponent<SoundController>().PlayItemPurchase();
        }
        else{
            errorText.SetActive(true);
        } 
    }

        

}
