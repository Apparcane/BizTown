using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PopularityAgencMenu : MonoBehaviour
{
    public bool IsAgencyPaid;

    public float PaidPrice = 500;
    public float AgencyUpgradePrice = 2500;
    public float AgencyLvl = 1f;
    public float PaidTimer = 0f;
    private float timer = 0f;
    private float popularityPerPaid = 25;

    public float inactivityThreshold = 5f;
    private float inactivityTimer = 0f;

    public GameObject Buton;
    public GameObject errorText;
    public Text UpgradePrice;
    public Text PaidPriceText;
    public Text AgencyLvlText;

    void Start()
    {
        Buton.SetActive(false);
        errorText.SetActive(false);
        IsAgencyPaid = false;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(GameManager.popularity >= 100f) GameManager.popularity = 100f;
        if(PaidTimer >= 43200) PaidTimer = 43200;
        if(PaidTimer <= 0 ) IsAgencyPaid = false;
        if (IsAgencyPaid && PaidTimer > 0)
    {
        PaidTimer -= Time.deltaTime;
    }
    if (PaidTimer <= 0)
    {
        IsAgencyPaid = false;
        PaidTimer = 0; 
        AgencyLvl = 1;
        AgencyUpgradePrice = 2500;
        PaidPrice = 500;
        popularityPerPaid = 25;

    }
    if(PaidTimer >= 0){
        IsAgencyPaid = true;
    }  
    
    inactivityTimer += Time.deltaTime;

    if (inactivityTimer >= inactivityThreshold)
        {
            Buton.SetActive(false);
            errorText.SetActive(false);
        }
    

    UpgradePrice.text = Mathf.FloorToInt(AgencyUpgradePrice) + " $";
    PaidPriceText.text = Mathf.FloorToInt(PaidPrice) + " $";
    AgencyLvlText.text = Mathf.FloorToInt(AgencyLvl) + " Lvl";

    }
    void ResetTimer()
    {
        inactivityTimer = 0f;
        Buton.SetActive(true);
    }

    private void OnMouseUpAsButton()
    {
        inactivityTimer = 0f;

         Debug.Log("Клик по агенству: " + gameObject.name);

        if (Buton != null)
        {
            Buton.SetActive(true);
        }
    }

    public void Paid(){

            if(GameManager.balance >= PaidPrice){
            IsAgencyPaid = true;
            GameManager.balance -= PaidPrice;
            PaidTimer +=10800f; 
            GameManager.popularity += popularityPerPaid;
        }
        
        else{
            errorText.SetActive(true);
        }
    }

    public void Upgrade(){
        if(IsAgencyPaid){
            if(GameManager.balance >= AgencyUpgradePrice){
            GameManager.balance -= AgencyUpgradePrice;
            AgencyLvl++;
            ResetTimer();
            popularityPerPaid += 5f;
            AgencyUpgradePrice *= 1.2f;
            PaidPrice *= 1.2f;
        }
        }
        
    }
}
