using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class PlayerHealth : MonoBehaviour
{


    // STATS

    private float maxHealth = 100f;

    [SerializeField]
    private float Health;

    private float regeneration = 2.25f;
    private float time_before_regeneration = 2.65f;

    ////////


    [SerializeField]
    private FloatGameEvent HealthBarEvent;
    private float previous_Health;

    [Range(0f,1f)]
    private float red_color = 1f; // player sprite red color intensity. 0 = strong red. 1 = normal color.
    private float timer_regeneration;
    private SpriteRenderer sprite;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        Health = maxHealth;
    }

    void Update()
    {
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

        if(timer_regeneration <= 0)
        {
            Health += regeneration * Time.deltaTime;
        }

        if(Health > 100)
        {
            Health = 100;
        }
        else if(Health <= 0)
        {
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
}
