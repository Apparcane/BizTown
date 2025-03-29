using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimBook : MonoBehaviour
{
    [SerializeField] private GameObject eventPanel;
    [SerializeField] private GameObject eventBook;
    [SerializeField] private Text eventText;

    private Coroutine eventCoroutine; // ��� ���������� ���������

    void OnEnable()
    {
        // ��� ��������� ������� ���������, ������� �� ������
        if (eventPanel != null && eventPanel.activeSelf)
        {
            StartEventSequence();
        }
    }

    // ����� ��� ��������� ������ (����������, ����� ����� �������� �����)
    public void TextActive()
    {
        if (eventText != null)
        {
            eventText.color = Color.black;
        }

        // ���� ������ �������, ��������� ������������������
        if (eventPanel != null && eventPanel.activeSelf)
        {
            StartEventSequence();
        }
    }

    // ����� ��� ������� ������������������ (��������� ������ � ��������)
    public void StartEventSequence()
    {
        if (eventPanel != null)
        {
            eventPanel.SetActive(true); // ��������, ��� ������ �������
            // ������������� ���������� ��������, ���� ��� ��� ��������
            if (eventCoroutine != null)
            {
                StopCoroutine(eventCoroutine);
            }
            eventCoroutine = StartCoroutine(EventOff());
        }
    }

    private IEnumerator EventOff()
    {
        // ���� 20 ������
        yield return new WaitForSeconds(20f);

        // ������ ����� ����������
        if (eventText != null)
        {
            eventText.color = Color.clear;
        }

        // ��������� ������
        if (eventPanel != null)
        {
            eventPanel.SetActive(false);
        }

        eventCoroutine = null; // ���������� ��������
    }

    void OnDisable()
    {
        // ������������� �������� ��� ����������� �������
        if (eventCoroutine != null)
        {
            StopCoroutine(eventCoroutine);
            eventCoroutine = null;
        }
    }
}