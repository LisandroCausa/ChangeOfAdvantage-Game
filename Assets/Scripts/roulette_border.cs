using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class roulette_border : MonoBehaviour
{

    public TextMeshProUGUI description_text;

    void OnEnable()
    {
        GetComponent<Image>().color = new Color(0.3396226f, 0.3396226f, 0.3396226f);
        description_text.text = "";
    }

}
