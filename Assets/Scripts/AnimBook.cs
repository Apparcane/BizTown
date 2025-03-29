using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimBook : MonoBehaviour
{
    [SerializeField] private GameObject eventPanel;
    [SerializeField] private GameObject eventBook;
    [SerializeField] private Text eventText;

    private Coroutine eventCoroutine; // Для управления корутиной

    void OnEnable()
    {
        // При активации объекта проверяем, активна ли панель
        if (eventPanel != null && eventPanel.activeSelf)
        {
            StartEventSequence();
        }
    }

    // Метод для активации текста (вызывается, когда нужно показать текст)
    public void TextActive()
    {
        if (eventText != null)
        {
            eventText.color = Color.black;
        }

        // Если панель активна, запускаем последовательность
        if (eventPanel != null && eventPanel.activeSelf)
        {
            StartEventSequence();
        }
    }

    // Метод для запуска последовательности (активация панели и ожидание)
    public void StartEventSequence()
    {
        if (eventPanel != null)
        {
            eventPanel.SetActive(true); // Убедимся, что панель активна
            // Останавливаем предыдущую корутину, если она уже запущена
            if (eventCoroutine != null)
            {
                StopCoroutine(eventCoroutine);
            }
            eventCoroutine = StartCoroutine(EventOff());
        }
    }

    private IEnumerator EventOff()
    {
        // Ждем 20 секунд
        yield return new WaitForSeconds(20f);

        // Делаем текст прозрачным
        if (eventText != null)
        {
            eventText.color = Color.clear;
        }

        // Отключаем панель
        if (eventPanel != null)
        {
            eventPanel.SetActive(false);
        }

        eventCoroutine = null; // Сбрасываем корутину
    }

    void OnDisable()
    {
        // Останавливаем корутину при деактивации объекта
        if (eventCoroutine != null)
        {
            StopCoroutine(eventCoroutine);
            eventCoroutine = null;
        }
    }
}