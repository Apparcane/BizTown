using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizePanel : MonoBehaviour
{
    public RectTransform panel; // Ссылка на панель
    public float expandedWidth = 600f;  // Ширина при увеличении
    public float expandedHeight = 400f; // Высота при увеличении
    public float normalWidth = 300f;    // Обычная ширина
    public float normalHeight = 200f;   // Обычная высота
    public float balanceThreshold = 10000f; // Лимит баланса

    void Update()
    {
        if (panel != null)
        {
            if (GameManager.getBalance() >= balanceThreshold)
            {
                // Увеличиваем размер панели
                panel.sizeDelta = new Vector2(expandedWidth, expandedHeight);
            }
            else
            {
                // Возвращаем обычный размер
                panel.sizeDelta = new Vector2(normalWidth, normalHeight);
            }
        }
    }

    

}
