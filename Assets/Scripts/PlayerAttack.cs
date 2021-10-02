using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private Animator animator;

    private bool canAttack = true;

    // STATS

    private float attackSpeed = 1;

    ////////

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if((Input.GetAxisRaw("Fire1") == 1 || Input.GetKey(KeyCode.Space)) && canAttack)
        {
            canAttack = false;
            StartCoroutine(attackWait(attackSpeed));
            Attack();
        }
    }

    IEnumerator attackWait(float time)
    {
        yield return new WaitForSeconds(time);
        canAttack = true;
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
