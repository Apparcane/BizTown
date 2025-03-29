using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource soundSource;       // AudioSource ��� �������� ��������
    [SerializeField] private AudioSource backgroundSource;  // AudioSource ��� ������� ������

    [Header("Sound Effects")]
    [SerializeField] private AudioClip[] soundClips;        // ������ ������
    [SerializeField] private AudioClip backgroundMusic;     // ������� ������

    private const int MONEY_ADD = 0;          // ������� ������ � �������
    private const int BIG_MONEY_ADD = 1;
    private const int LEVEL_UP = 2;
    private const int MONEY_SPEND = 3;
    private const int ITEM_PURCHASE = 4;

    void Start()
    {
        // �������� �� ������� �����������
        if (soundSource == null || backgroundSource == null)
        {
            Debug.LogError("AudioSource components are not assigned!");
            return;
        }

        // �������� ������� ������
        if (soundClips == null || soundClips.Length < 5)
        {
            Debug.LogError("Sound clips array is not properly configured!");
            return;
        }

        // ��������� � ������ ������� ������
        if (backgroundMusic != null)
        {
            backgroundSource.clip = backgroundMusic;
            backgroundSource.loop = true;
            backgroundSource.Play();
        }
    }

    // ���� ���������� �����
    public void PlayMoneyAdd()
    {
        PlaySound(MONEY_ADD);
    }

    // ���� ���������� �������� ���������� �����
    public void PlayBigMoneyAdd()
    {
        PlaySound(BIG_MONEY_ADD);
    }

    // ���� ��������� ������
    public void PlayLevelUp()
    {
        PlaySound(LEVEL_UP);
    }

    // ���� ����� �����
    public void PlayMoneySpend()
    {
        PlaySound(MONEY_SPEND);
    }

    // ���� ������� ��������
    public void PlayItemPurchase()
    {
        PlaySound(ITEM_PURCHASE);
    }

    // ��������������� ������� ��� ��������������� �����
    private void PlaySound(int clipIndex)
    {
        if (soundSource != null && soundClips[clipIndex] != null)
        {
            soundSource.PlayOneShot(soundClips[clipIndex]);
        }
    }

    // ����� ��� ��������� ������� ������ (�����������)
    public void StopBackgroundMusic()
    {
        if (backgroundSource != null)
        {
            backgroundSource.Stop();
        }
    }

    // ����� ��� ������������� ������� ������ (�����������)
    public void ResumeBackgroundMusic()
    {
        if (backgroundSource != null && !backgroundSource.isPlaying)
        {
            backgroundSource.Play();
        }
    }
}
