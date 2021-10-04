using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool canMove = true;

    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 movement;

    private float moveSpeed = 220;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(canMove == false || PlayerHealth.game_over == true)
        {
            movement = new Vector2(0, 0); // No movement
        }

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
    }

}
