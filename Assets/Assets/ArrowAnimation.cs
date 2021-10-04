using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnimation : MonoBehaviour
{

    private SpriteRenderer sprite;
    private bool do_animation = false;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    IEnumerator anim()
    {
        sprite.enabled = true;
        yield return new WaitForSecondsRealtime(0.5f);
        sprite.enabled = false;
        yield return new WaitForSecondsRealtime(0.25f);

        if(do_animation) StartCoroutine(anim());
    }

    public void Activate()
    {
        do_animation = true;
        StartCoroutine(anim());
    }

    public void DeActivate()
    {
        do_animation = false;
    }

}
