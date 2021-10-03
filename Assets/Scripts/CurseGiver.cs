using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurseGiver : MonoBehaviour
{

    [SerializeField]
    private Roulette roulette;
    [SerializeField]
    private Image roulette_border;
    [SerializeField]
    private TextMeshProUGUI roulette_description_text;

    private Curses curses_script_reference;

    void Awake()
    {
        curses_script_reference = GetComponent<Curses>();   
    }


    public void GetNewCurse(int index)
    {
        curses_script_reference.DeleteOldCurses();

        /*

            0 = Sword (Attack Damage)
            1 = Heart (Health)

        */

        bool advantageRandom = Random.Range(0, 2) == 1;

        Debug.Log(advantageRandom);

        int percentage = Random.Range(1,11);
        percentage *= 5;

        if(advantageRandom == false) percentage = -percentage;

        if(index == 1)
        {
            if(advantageRandom)
            {
                percentage = 50;
            }
            else
            {
                percentage = -50;
            }
        }


        // Do border effect
        if(advantageRandom)
        {
            roulette_border.color = curses_script_reference.advantage;
        }
        else
        {
            roulette_border.color = curses_script_reference.no_advantage;
        }


        Curse c = new Curse{
            sprite = roulette.sprites[index],
            isAdvantage = advantageRandom,
            duration = 1
        };

        switch(index)
        {
            case 0:
                c.damage += percentage;
                if(advantageRandom)
                {
                    c.description = "You gain %" + percentage.ToString() + " of your Damage.";
                }
                else
                {
                    c.description = "You lose %" + (-percentage).ToString() + " of your Damage.";
                }
                break;
            case 1:
                c.health += percentage;
                if(advantageRandom)
                {
                    c.description = "You gain %" + percentage.ToString() + " of your Max Health.";
                }
                else
                {
                    c.description = "You lose %" + (-percentage).ToString() + " of your Max Health.";
                }
                break;
        }

        roulette_description_text.text = c.description;

        curses_script_reference.curses.Add(c);
        curses_script_reference.UpdateCurses();
    }
}
