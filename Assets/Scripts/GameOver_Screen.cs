using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectArchitecture;

public class GameOver_Screen : MonoBehaviour
{
    [SerializeField]
    private Image background;
    [SerializeField]
    private GameObject UI_Elements;

    private bool fadeIn_bg;
    private float alpha_bg;

    [Space,Space]
    [SerializeField]
    private GameEvent restart_all_event;

    [SerializeField]
    private GameEvent set_round_text;



    void Update()
    {
        if(fadeIn_bg)
        {
            alpha_bg += Time.deltaTime;
            if(alpha_bg >= 1f)
            {
                alpha_bg = 1f;
                fadeIn_bg = false;
                UI_Elements.SetActive(true);
                set_round_text.Raise();
            }
            background.color = new Color(background.color.r, background.color.g, background.color.b, alpha_bg);
        }
    }

    public void GameOver()
    {
        background.enabled = true;
        fadeIn_bg = true;
    }

    public void Restart()
    {
        UI_Elements.SetActive(false);

        alpha_bg = 0;
        background.color = new Color(background.color.r, background.color.g, background.color.b, alpha_bg);
        background.enabled = false;

        restart_all_event.Raise(); // Restart Level
    }
}
