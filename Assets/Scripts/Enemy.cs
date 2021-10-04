using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private FloatGameEvent AttackPlayerEvent;


    private Transform player_position;

    private Vector2 enemyVector2;
    private Vector2 playerVector2;

    // STATIC STATS

    private float min_moveSpeed = 1.5f;
    private float max_moveSpeed = 3.6f;

    // STATS

    private float attackRange = 1f;
    private float attackSpeed = 0.5f;
    private float attackDamage = 1.75f;

    private float Health = 10f;

    /////////

    private bool canAttack = true;
    private bool X_direction;
    private SpriteRenderer sprite;
    private float red_intensity = 1f;
    private AudioSource audio_hit;



    private AIDestinationSetter destination;
    private AIPath AI;

    void Start()
    {
        audio_hit = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        destination = GetComponent<AIDestinationSetter>();
        AI = GetComponent<AIPath>();
        player_position = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        destination.target = player_position;

        Debug.Log("Enemy: "+ Curses.Enemy_SpeedMultiplier);
        AI.maxSpeed = Random.Range(min_moveSpeed, max_moveSpeed) * Curses.Enemy_SpeedMultiplier;
        if(LevelManager.tutorial) attackDamage = 0.5f;
    }
    

    void Update()
    {
        if(Health <= 0)
        {
            Health = 1000;
            attackSpeed = 10f;
            canAttack = false;
            StartCoroutine(WaitForDeath());
        }


        enemyVector2 = new Vector2(transform.position.x, transform.position.y);
        playerVector2 = new Vector2(player_position.position.x, player_position.position.y);

        if(Vector2.Distance(enemyVector2, playerVector2) > attackRange)
        {
            AI.canMove = true;
        }
        else
        {
            AI.canMove = false;
            if(canAttack)
            {
                canAttack = false;
                StartCoroutine(attackWait(attackSpeed));
                Attack();
            }
        }


        X_direction = transform.position.x <= player_position.position.x;

        if(X_direction)
        {
            transform.localScale = new Vector3(0.8f, 0.8f, 1);
        }
        else 
        {
            transform.localScale = new Vector3(-0.8f, 0.8f, 1);
        }
        

        if(red_intensity >= 1)
        {
            red_intensity = 1;
        }
        else
        {
            red_intensity += Time.deltaTime * 2.35f;
            if(red_intensity >= 1)
            {
            red_intensity = 1;
            }
            sprite.color = new Color(1, red_intensity, red_intensity);

        }
    }

    IEnumerator attackWait(float time)
    {
        yield return new WaitForSeconds(time);
        canAttack = true;
    }

    IEnumerator WaitForDeath()
    {
        transform.SetParent(null);
        GetComponent<Animator>().enabled = false;
        sprite.sprite = null;
        GetComponent<BoxCollider2D>().enabled = false;
        AI.canMove = false;
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    void Attack()
    {
        AttackPlayerEvent.Raise(attackDamage);
    }

    public void Hurt(float damage)
    {
        Health -= damage;
        red_intensity = 0;
        audio_hit.pitch = Random.Range(0.8f, 1.3f);
        audio_hit.Play();
        // Do Animation

    }
}
