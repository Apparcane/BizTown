using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyFactory : MonoBehaviour
{

    private static float price = 1500f;

    private bool isFactoryPurchased = false;

    private MonoBehaviour currentScript;
    public MonoBehaviour nextScript;

    // Start is called before the first frame update
    void Start()
    {
        isFactoryPurchased = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static void PushedFactory(){
        if(GameManager.getBalance() >= price){
            GameManager.setBalance(GameManager.getBalance() - price);

            isFactoryPurchased = true;

            currentScript.enabled = false;
            nextScript.enabled = true;

        }
    }
}
