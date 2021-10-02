using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 movement;

    [SerializeField]
    private float moveSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(movement.x != 0 || movement.y != 0) // Send previous direction to Animator
        {
            animator.SetFloat("previous_Horizontal", movement.x);
            animator.SetFloat("previous_Vertical", movement.y);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * moveSpeed * Time.fixedDeltaTime, movement.y * moveSpeed * Time.fixedDeltaTime);
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
