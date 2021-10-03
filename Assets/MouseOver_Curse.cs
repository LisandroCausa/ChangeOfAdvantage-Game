using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver_Curse : MonoBehaviour
{
    [SerializeField]
    private GameObject DescriptionText;

    public void Show()
    {
        DescriptionText.SetActive(true);
    }

    public void Hide()
    {
        DescriptionText.SetActive(false);
    }
}
