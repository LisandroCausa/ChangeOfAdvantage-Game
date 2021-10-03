using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Curse
{

    public Sprite sprite;

    public bool isAdvantage;
    
    public string description;

    public int duration = 1; // In number of Rounds



    [Space,Header("Changes in %")]

    // Attack Stats
    public int damage;
    public int attack_speed;

    // Movement Stats
    public int speed;

    // Other
    public int health;
}
