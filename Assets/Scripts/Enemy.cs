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

    // STATS
    private float min_moveSpeed = 1.7f;
    private float max_moveSpeed = 3.7f;

    private float attackRange = 1.5f;
    private float attackSpeed = 0.5f;
    private float attackDamage = 3f;

    /////////

    private bool canAttack = true;
    private bool X_direction;



    private AIDestinationSetter destination;
    private AIPath AI;

    void Awake()
    {
        destination = GetComponent<AIDestinationSetter>();
        AI = GetComponent<AIPath>();
        player_position = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        destination.target = player_position;
        AI.maxSpeed = Random.Range(min_moveSpeed, max_moveSpeed);

    }
    

    void Update()
    {
        enemyVector2 = new Vector2(transform.position.x, transform.position.y);
        playerVector2 = new Vector2(player_position.position.x, player_position.position.y);

        if(Vector2.Distance(enemyVector2, playerVector2) > attackRange)
        {
            //transform.position = Vector2.MoveTowards(transform.position, player_position.position, moveSpeed * Time.deltaTime);
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

    }

    IEnumerator attackWait(float time)
    {
        yield return new WaitForSeconds(time);
        canAttack = true;
    }


    void Attack()
    {
        Debug.Log("Attack!");
        AttackPlayerEvent.Raise(attackDamage);
    }
}
