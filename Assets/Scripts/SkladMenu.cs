using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkladMenu : MonoBehaviour
{
    public float productBalance = 0f;
    public float productSellPrice = 500;
    public float MaxCapacity = 150;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(productBalance >= MaxCapacity) productBalance = MaxCapacity;

    }

    private void SellProduct(){
        if(productBalance > 0){
            

        }
    }
}
