using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public GameObject Door;
    public GameObject WinZone;


    public void LevelStart()
    {
        Door.SetActive(true);
        WinZone.SetActive(false);
    }

    public void LevelEnd()
    {
        Door.SetActive(false);
        WinZone.SetActive(true);
    }

}
