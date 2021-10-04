using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialText : MonoBehaviour
{

    void Update()
    {
        if(LevelManager.tutorial == false)
        {
            Destroy(this.gameObject);
        }
    }
}
