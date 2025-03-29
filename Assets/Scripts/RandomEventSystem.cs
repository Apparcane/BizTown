using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RandomEventSystem : MonoBehaviour
{
    public int minEventTime = 180; // 3 минуты в секундах (3 * 60)
    public int maxEventTime = 300; // 5 минут в секундах (5 * 60)

    private bool isEventTriggered = false; // Флаг для предотвращения множественных вызовов
    private Coroutine eventCoroutine; // Для управления корутиной

    [SerializeField] private GameObject eventPanel;
    [SerializeField] private GameObject eventBook;
    [SerializeField] private Text eventText;

    [SerializeField] private bool ActiveEvent = false;


    private void Start()
    {
        StartCoroutine(EventRoutine());
    }

    private void Update()
    {
        if(ActiveEvent)
        {
            ActiveEvent = false;
            TriggerRandomEvent();
        }
    }

    IEnumerator EventRoutine()
    {
        while (true)
        {
            // Ждем случайное время перед следующим событием
            float waitTime = Random.Range(minEventTime, maxEventTime);
            Debug.Log(waitTime);
            yield return new WaitForSeconds(waitTime);

            // Запускаем событие
            TriggerRandomEvent();
        }
    }

    void TriggerRandomEvent()
    {
        int eventType = Random.Range(0, 3);
        float deduction = GameManager.balance * 0.5f;
        eventPanel.SetActive(true);
        eventBook.GetComponent<Animator>().SetTrigger("Event");

        switch (eventType)
        {
            case 0:
                GameManager.balance -= deduction;
                Debug.Log($"Пограбування! Втраченно 50% балансу ({deduction}). Новий баланс: {GameManager.balance}");
                GameObject.Find("SoundController").GetComponent<SoundController>().PlayMoneySpend();
                eventText.text = $"Пограбування! Втраченно 50% балансу ({deduction}). Новий баланс: {GameManager.balance}";
                break;
            case 1:
                float repairCost = GameManager.balance * 0.3f;
                GameManager.balance -= repairCost;
                Debug.Log($"Пошкодження обладнання! Втраченно 30% балансу ({repairCost}). Новий баланс: {GameManager.balance}");
                GameObject.Find("SoundController").GetComponent<SoundController>().PlayMoneySpend();
                eventText.text = $"Пошкодження обладнання! Втраченно 30% балансу ({repairCost}). Новий баланс: {GameManager.balance}";
                break;
            case 2:
                float profit = GameManager.balance * 0.08f;
                GameManager.balance += profit;
                Debug.Log($"Успішна інвестиція! Прибуток 8% ({profit}). Новий баланс: {GameManager.balance}");
                GameObject.Find("SoundController").GetComponent<SoundController>().PlayBigMoneyAdd();
                eventText.text = $"Успішна інвестиція! Прибуток 8% ({profit}). Новий баланс: {GameManager.balance}";
                break;
        }
    }
}