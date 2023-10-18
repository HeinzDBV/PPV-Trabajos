
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

    [SerializeField]
    private AudioSource jumpSoundEffect;
    [SerializeField]
    private AudioSource WalkSound;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsJumping", false);
            return;
        }
        else
        {
            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = new Vector2(moveDirection.x, moveDirection.z);
            // moveDir = playerInput.actions["Move"].ReadValue<Vector2>();
                    moveDir.Normalize();
            rb.velocity = new Vector3
            (
            moveDir.x * Speed.x,
            rb.velocity.y,
            moveDir.y * Speed.z
            );
            // WalkSoundStart();


            isGrounded = CheckGrounded();
            bool jumpPressed = InputManager.GetInstance().GetJumpPressed();
            UpdateAnimation();
            if (isGrounded && jumpPressed)
            {
                Jump();
                jumpSoundEffect.Play();
            }
        }



    }

    // IEnumerator WalkSoundStart()
    // {
    //     while(animator.GetBool("IsWalking") == true)
    //     {   
    //         WalkSound.Play();
    //         yield return new WaitForSeconds(0.7f);
    //     }
    //     if(animator.GetBool("IsWalking") == false)
    //     {
    //         WalkSound.Stop();
    //     }
    // }
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        animator.SetBool("IsJumping", true);

    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
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
        if (rb.velocity.y <= 0f)
        {
            if (Physics.Raycast(transform.position, Vector3.down, raycastDistance, 1 << LayerMask.NameToLayer("Ground")))
            {
                return true;
            }
        }

        return false;
    }
}



