using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public GameObject door;
    public GameObject WinZone;


    public void LevelEnd()
    {
        Destroy(door);
        WinZone.SetActive(true);
    }
}
