using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private FloatGameEvent AttackPlayerEvent;

    private Transform player_position;

    private Vector2 enemyVector2;
    private Vector2 playerVector2;

    private float moveSpeed = 3f;
    private float attackRange = 1.5f;
    private float attackSpeed = 0.5f;
    private float attackDamage = 3f;

    private bool canAttack = true;
    private bool X_direction;

    void Awake()
    {
        player_position = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        enemyVector2 = new Vector2(transform.position.x, transform.position.y);
        playerVector2 = new Vector2(player_position.position.x, player_position.position.y);

        if(Vector2.Distance(enemyVector2, playerVector2) > attackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player_position.position, moveSpeed * Time.deltaTime);
        }
        else if(canAttack)
        {
            canAttack = false;
            StartCoroutine(attackWait(attackSpeed));
            Attack();
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
