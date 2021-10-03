using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Curses : MonoBehaviour
{

    public List<Curse> curses = new List<Curse>();

    public GameObject curseTemplate;

    public Color advantage;
    public Color no_advantage;



    public void UpdateCurses()
    {
        foreach(Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
        

        foreach(Curse c in curses)
        {
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
}
