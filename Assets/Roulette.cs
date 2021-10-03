using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectArchitecture;

public class Roulette : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();

    private AudioSource audio_source;
    private Image image;

    /*[SerializeField]
    private Image border;*/

    private int sprite_index;
    private int previous_sprite_index = -666;

    public Button next_button;
    public Curses curses_script_reference;

    [SerializeField]
    private IntGameEvent curse_messenger;


    void Awake()
    {
        image = GetComponent<Image>();
        audio_source = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        spin();
    }

    public void spin()
    {
        StartCoroutine(spinCoroutine());
        audio_source.Play();
    }

    IEnumerator spinCoroutine()
    {
        for(int i = 0; i < 21; i++)
        {
            do
            {
                sprite_index = Random.Range(0, sprites.Count);
            }while(sprite_index == previous_sprite_index);
            previous_sprite_index = sprite_index;

            image.sprite = sprites[sprite_index];
            yield return new WaitForSeconds(0.10f);
        }

        /*if(Random.Range(0,2) == 0)
        {
            // Bad
            border.color = curses_script_reference.no_advantage;
        }
        else
        {
            border.color = curses_script_reference.advantage;
        }*/


        curse_messenger.Raise(sprite_index); // Give sprite_index Curse


        next_button.interactable = true;
    }

}
