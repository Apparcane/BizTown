using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour
{

    [SerializeField] private factoryMenu[] Factorys;

    private float baseIncome = 5f;
    private int increment = 1;
    private int totalLvl = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("getCash");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator getCash() {
        while (true) {
            getTotalLvl();
            GameManager.setBalance(GameManager.getBalance() + totalLvl * baseIncome * increment);
            yield return new WaitForSeconds(1f);
        }
    }

    private void getTotalLvl() {
        totalLvl = 0;
        for(int i = 0; i < Factorys.Length; i++) {
            totalLvl += Factorys[i].factoryLvl;
        }
    }
}
