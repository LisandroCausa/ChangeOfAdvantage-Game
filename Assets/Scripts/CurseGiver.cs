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
            2 = Slime_Speed

        */

        bool advantageRandom = Random.Range(0, 2) == 1;

        //if(LevelManager.round > 4) advantageRandom = Random.Range(0,5) > 2; AGREGAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR


        int percentage = Random.Range(2,9);
        percentage *= 10;

        if(advantageRandom == false) percentage = -percentage;

        if(index == 1)
        {
            percentage = 50;
            if(!advantageRandom) percentage = -50;
        }
        else if(index == 2)
        {
            if(advantageRandom)
            {
                percentage = Random.Range(2,10);
            }
            else
            {
                percentage = Random.Range(-25,-2);
            }
            percentage *= 10;
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
            curse_index = index,
            sprite = roulette.sprites[index],
            isAdvantage = advantageRandom,
            duration = 1
        };

        if(LevelManager.round > 2) //&& Random.Range(0,3) > 0)
        {
            c.duration += Random.Range(1,3);
        }

        switch(index)
        {
            case 0:
                c.damage = percentage;
                if(advantageRandom)
                {
                    c.description = "You gain %" + percentage.ToString() + " of your Damage";
                }
                else
                {
                    c.description = "You lose %" + (-percentage).ToString() + " of your Damage";
                }
                break;
            case 1:
                c.health = percentage;
                if(advantageRandom)
                {
                    c.description = "You gain %" + percentage.ToString() + " of your Max Health";
                }
                else
                {
                    c.description = "You lose %" + (-percentage).ToString() + " of your Max Health";
                }
                break;
            case 2:
                c.slime_speed = percentage;
                if(advantageRandom)
                {
                    c.description = "Slimes are %" + percentage.ToString() + " slower";
                }
                else
                {
                    c.description = "Slimes are %" + (-percentage).ToString() + " faster";
                }
                break;
        }

        roulette_description_text.text = c.description;

        curses_script_reference.curses.Add(c);
        curses_script_reference.UpdateCurses();
    }
}
