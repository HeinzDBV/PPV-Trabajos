using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement3D : MonoBehaviour
{
    [SerializeField]
    private Vector3 Speed = new Vector3(4f, 0f, 4f);

    private Rigidbody rb;
    private Animator animator;
    private PlayerInput playerInput;

    private Vector2 moveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        moveDir.Normalize();
        rb.velocity = new Vector3(
            moveDir.x * Speed.x,
            rb.velocity.y,
            moveDir.y * Speed.z
        );
    }
    
    private void OnWalk(InputValue value)
    {
        moveDir = value.Get<Vector2>();
        if (Mathf.Abs(moveDir.x) > Mathf.Epsilon ||
            Mathf.Abs(moveDir.y) > Mathf.Epsilon)
        {
            animator.SetBool("IsWalking", true);
            animator.SetFloat("Horizontal", moveDir.x);
            animator.SetFloat("Vertical", moveDir.y);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

    }

}
