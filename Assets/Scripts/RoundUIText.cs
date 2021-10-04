using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundUIText : MonoBehaviour
{
    private TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText()
    {
        text.text = "Round " + LevelManager.round.ToString();
    }

    public void ResetRounds()
    {
        UpdateText();
        LevelManager.round = 1;
    }

}
