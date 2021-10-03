using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{

    public GameObject AfterLevel_Canvas;
    public Image AfterLevel_Background;
    public GameObject AfterLevel_Window;

    private bool transitioning;
    private float alphaBackground;


    void Update()
    {
        if(transitioning)
        {
            alphaBackground += Time.deltaTime;
            if(alphaBackground >= 1f)
            {
                alphaBackground = 1f;
                transitioning = false;
            }
            AfterLevel_Background.color = new Color(AfterLevel_Background.color.r, AfterLevel_Background.color.g, AfterLevel_Background.color.b, alphaBackground);
        }
        else if(AfterLevel_Canvas.activeSelf)
        {
            AfterLevel_Window.SetActive(true);
        }
    }

    public void DoTransition()
    {
        AfterLevel_Canvas.SetActive(true);
        AfterLevel_Window.SetActive(false);
        AfterLevel_Background.color = new Color(AfterLevel_Background.color.r, AfterLevel_Background.color.g, AfterLevel_Background.color.b, 0);
        alphaBackground = 0;

        transitioning = true;
    }
}
