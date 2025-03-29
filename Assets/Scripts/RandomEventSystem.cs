using System.Collections;
using UnityEngine;

public class RandomEventSystem : MonoBehaviour
{
    public float minEventTime = 3f * 3600f; // 3 часа в секундах
    public float maxEventTime = 8f * 3600f; // 8 часов в секундах

    void Start()
    {
        StartCoroutine(EventRoutine());
    }

    IEnumerator EventRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minEventTime, maxEventTime);
            yield return new WaitForSeconds(waitTime);
            TriggerRandomEvent();
        }
    }

    void TriggerRandomEvent()
    {
        int eventType = Random.Range(0, 3);
        float deduction = GameManager.balance * 0.5f;
        
        switch (eventType)
        {
            case 0:
                GameManager.balance -= deduction;
                Debug.Log($"Ограбление! Потеряно 10% баланса ({deduction}). Новый баланс: {GameManager.balance}");
                break;
            case 1:
                float repairCost = GameManager.balance * 0.3f;
                GameManager.balance -= repairCost;
                Debug.Log($"Поломка оборудования! Потеряно 5% баланса ({repairCost}). Новый баланс: {GameManager.balance}");
                break;
            case 2:
                float profit = GameManager.balance * 0.08f;
                GameManager.balance += profit;
                Debug.Log($"Удачная инвестиция! Прибыль 8% ({profit}). Новый баланс: {GameManager.balance}");
                break;
        }
    }
}
