using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 Speed = new Vector3(4f, 0f, 4f);
    [SerializeField]
    private float jumpForce = 5.0f;

    private Rigidbody rb;
    private Animator animator;
    private PlayerInput playerInput;
    private bool isGrounded;
    private Vector2 moveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        moveDir = playerInput.actions["Move"].ReadValue<Vector2>();

        moveDir.Normalize();
        rb.velocity = new Vector3(
            moveDir.x * Speed.x,
            rb.velocity.y,
            moveDir.y * Speed.z
        );

        //isGrounded = CheckGrounded();

        if (isGrounded && playerInput.actions["Jump"].triggered)
        {
            Jump();
        }
        isGrounded = CheckGrounded(); 
        UpdateAnimation();
    }

    private void Jump()
    {
        Debug.Log("salte");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        animator.SetBool("IsJumping", true);
    }


    private void UpdateAnimation()
    {
        if (isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }

        if (Mathf.Abs(moveDir.x) > Mathf.Epsilon || Mathf.Abs(moveDir.y) > Mathf.Epsilon)
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

    private bool CheckGrounded()
    {
        float raycastDistance = 0.6f;

        if (Physics.Raycast(transform.position, Vector3.down, raycastDistance, 1 << LayerMask.NameToLayer("Ground")))
        {
            return true;
        }

        return false;
    }
}


