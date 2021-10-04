using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public GameObject Door;
    public GameObject WinZone;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void LevelStart()
    {
        Door.SetActive(true);
        WinZone.SetActive(false);
    }

    public void LevelEnd()
    {
        audioSource.Play();
        Door.SetActive(false);
        WinZone.SetActive(true);
    }

}
