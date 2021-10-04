using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class PlayerHealth : MonoBehaviour
{

    // STATIC STATS

    private int initial_maxHealth = 100;

    // STATS

    private float maxHealth;

    [SerializeField]
    private float Health;

    private float regeneration = 3.25f;
    private float time_before_regeneration = 2.5f;

    ////////


    [SerializeField]
    private FloatGameEvent HealthBarEvent;
    private float previous_Health;

    [Range(0f,1f)]
    private float red_color = 1f; // player sprite red color intensity. 0 = strong red. 1 = normal color.
    private float timer_regeneration;
    private SpriteRenderer sprite;

    [SerializeField]
    private GameEvent game_over_event;


    public static bool game_over;



    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        ResetGameOver();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("ABC: "+(float)40/100);
        }
        red_color += Time.deltaTime/2;
        if(red_color > 1f)
        {
            red_color = 1f;
        }
        else if(red_color < 0f)
        {
            red_color = 0f;
        }
        sprite.color = new Color(1, red_color, red_color);


        timer_regeneration -= Time.deltaTime;

        if(timer_regeneration <= 0 && game_over == false)
        {
            Health += regeneration * Time.deltaTime;
        }

        if(Health > maxHealth)
        {
            Health = maxHealth;
        }
        else if(Health <= 0)
        {
            if(!game_over) game_over_event.Raise();
            game_over = true;
            // GAME OVER
        }

        if(previous_Health != Health)
        {
            if(previous_Health > Health) // Player got damaged
            {
                timer_regeneration = time_before_regeneration;
            }
            HealthBarEvent.Raise(Health/100);
            previous_Health = Health;
        }
    }

    public void GetDamage(float damage)
    {
        Health -= damage;
        red_color -= 0.5f;
    }

    public void ResetGameOver()
    {
        game_over = false;
        maxHealth = initial_maxHealth;
        Health = maxHealth;
        red_color = 1f;
    }

    public void ResetStats()
    {
        maxHealth = initial_maxHealth;
        Health = maxHealth;
    }

    public void HealthChange(int percentage)
    {
        maxHealth = maxHealth + (maxHealth/100) * percentage;
        Health = maxHealth;
    }
}
