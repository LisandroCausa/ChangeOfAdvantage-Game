using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roulette_border : MonoBehaviour
{

    void OnEnable()
    {
        GetComponent<Image>().color = new Color(0.3396226f, 0.3396226f, 0.3396226f);
    }

}
