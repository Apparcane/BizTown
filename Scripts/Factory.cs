using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Factory : MonoBehaviour
{

    public float boxBalance = 0f; // Количество товара
    public static float incomePerSecond = 10f; // Товар пасивно в секунду

    public Text IncomePerSec;

    // Start is called before the first frame update
    void Start()
    {
        

        
    }
    void Update()
    {

       IncomePerSec.text = incomePerSecond.ToString("1") + " $/h";
    }


}
