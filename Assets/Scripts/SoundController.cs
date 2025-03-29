using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource soundSource;       // AudioSource для звуковых эффектов
    [SerializeField] private AudioSource backgroundSource;  // AudioSource для фоновой музыки

    [Header("Sound Effects")]
    [SerializeField] private AudioClip[] soundClips;        // Массив звуков
    [SerializeField] private AudioClip backgroundMusic;     // Фоновая музыка

    private const int MONEY_ADD = 0;          // Индексы звуков в массиве
    private const int BIG_MONEY_ADD = 1;
    private const int LEVEL_UP = 2;
    private const int MONEY_SPEND = 3;
    private const int ITEM_PURCHASE = 4;

    void Start()
    {
        // Проверка на наличие компонентов
        if (soundSource == null || backgroundSource == null)
        {
            Debug.LogError("AudioSource components are not assigned!");
            return;
        }

        // Проверка массива звуков
        if (soundClips == null || soundClips.Length < 5)
        {
            Debug.LogError("Sound clips array is not properly configured!");
            return;
        }

        // Настройка и запуск фоновой музыки
        if (backgroundMusic != null)
        {
            backgroundSource.clip = backgroundMusic;
            backgroundSource.loop = true;
            backgroundSource.Play();
        }
    }

    // Звук зачисления денег
    public void PlayMoneyAdd()
    {
        PlaySound(MONEY_ADD);
    }

    // Звук зачисления большого количества денег
    public void PlayBigMoneyAdd()
    {
        PlaySound(BIG_MONEY_ADD);
    }

    // Звук улучшения уровня
    public void PlayLevelUp()
    {
        PlaySound(LEVEL_UP);
    }

    // Звук траты денег
    public void PlayMoneySpend()
    {
        PlaySound(MONEY_SPEND);
    }

    // Звук покупки предмета
    public void PlayItemPurchase()
    {
        PlaySound(ITEM_PURCHASE);
    }

    // Вспомогательная функция для воспроизведения звука
    private void PlaySound(int clipIndex)
    {
        if (soundSource != null && soundClips[clipIndex] != null)
        {
            soundSource.PlayOneShot(soundClips[clipIndex]);
        }
    }

    // Метод для остановки фоновой музыки (опционально)
    public void StopBackgroundMusic()
    {
        if (backgroundSource != null)
        {
            backgroundSource.Stop();
        }
    }

    // Метод для возобновления фоновой музыки (опционально)
    public void ResumeBackgroundMusic()
    {
        if (backgroundSource != null && !backgroundSource.isPlaying)
        {
            backgroundSource.Play();
        }
    }
}
