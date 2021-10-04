using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Curses : MonoBehaviour
{

    public List<Curse> curses = new List<Curse>();

    public GameObject curseTemplate;

    [Space]
    public Color advantage;
    public Color no_advantage;


    [Space,Space]
    [SerializeField]
    private GameEvent ResetAllStats;
    [Space,Space]
    [SerializeField]
    private IntGameEvent Damage_change;
    [SerializeField]
    private IntGameEvent Health_change;
    public static float Enemy_SpeedMultiplier;

    void Start()
    {
        Enemy_SpeedMultiplier = 1;
    }

    public void UpdateCurses()
    {
        foreach(Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
        

        ResetAllStats.Raise(); // Reset All the Stats percentages from the game
        Enemy_SpeedMultiplier = 1f;


        foreach(Curse c in curses)
        {
            #region VISUAL EFFECTS

            var newCurse = Instantiate(curseTemplate, transform.position, Quaternion.identity);
            newCurse.transform.SetParent(this.transform);
            newCurse.GetComponent<RectTransform>().localPosition = new Vector2(-675, 200 - 170 * curses.IndexOf(c));
            newCurse.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            var elements_references = newCurse.GetComponent<Curse_UI_Elements_Reference>();
            elements_references.sprite.GetComponent<Image>().sprite = c.sprite;

            if(c.isAdvantage)
            {
                elements_references.border.GetComponent<Image>().color = advantage;
            }
            else
            {
                elements_references.border.GetComponent<Image>().color = no_advantage;
            }

            elements_references.description.GetComponent<TextMeshProUGUI>().text = c.description;

            #endregion

            switch(c.curse_index)
            {
                case 0:
                    Damage_change.Raise(c.damage);
                    break;
                case 1:
                    Health_change.Raise(c.health);
                    break;
                case 2:
                    int original_perc = -(c.slime_speed);
                    float perc = (float)original_perc/100;
                    Enemy_SpeedMultiplier = 1f + perc;
                    break;
            }

        }
    }


    public void DeleteOldCurses()
    {
        List<Curse> CursesToDelete = new List<Curse>();

        foreach(Curse c in curses)
        {
            c.duration--;
            if(c.duration <= 0)
            {
                CursesToDelete.Add(c);
            }
        }

        foreach(Curse x in CursesToDelete)
        {
            curses.Remove(x);
        }
    }

    public void ResetCurses()
    {
        curses = new List<Curse>();
        UpdateCurses();
    }
}
