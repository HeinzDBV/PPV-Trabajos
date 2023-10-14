using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]


public class CharacterController3D : MonoBehaviour
{
    [Header("Movement Params")]
    private float speed;
    public float walkSpeed = 1.0f;
    public float runSpeed = 4.0f;
    public float jumpForce = 8.0f;
    public float gravityScale = 20.0f;
    private PlayerInput playerInput;

    private BoxCollider coll;
    private Rigidbody rb;

    // Animation
    private Animator animator;
    private Vector2 moveDir;


    private bool isGrounded = false;

    private void Awake()
    {
        coll = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rb.freezeRotation = true; // Prevent rotation due to physics interactions
        
    }

    private void Update()
    {
        Physics.gravity = new Vector3(0, -gravityScale, 0);
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsJumping", false);
            return;
        }
        
        UpdateIsGrounded();
        HandleHorizontalMovement();
        HandleJumping();
    }

    //MOVEMENT AND ANIMATIONS

    private void HandleHorizontalMovement()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDir = new Vector2(moveDirection.x, moveDirection.z); 
        
        // Set moveDir based on the input direction
        
        moveDir.Normalize();
        rb.velocity = new Vector3(moveDirection.x * speed,moveDirection.y, moveDirection.z * speed);

        // Call OnWalking to update the animator parameters
        OnWalking();
        OnRunning();
        OnJumping();
    }

    private void HandleJumping()
    {
        isGrounded = UpdateIsGrounded();
        bool jumpPressed = InputManager.GetInstance().GetJumpPressed();
        if (isGrounded && jumpPressed)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // isGrounded = false;
            // rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
        
    }

    private void OnWalking()
    {
        if (Mathf.Abs(moveDir.x) > Mathf.Epsilon || Mathf.Abs(moveDir.y) > Mathf.Epsilon)
        {
            speed = walkSpeed;
            animator.SetBool("IsWalking", true);
            animator.SetFloat("Horizontal", moveDir.x);
            animator.SetFloat("Vertical", moveDir.y);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
    private void OnJumping()
    {
        // bool jumpPressed = InputManager.GetInstance().GetJumpPressed();
        if (Mathf.Abs(moveDir.x) > Mathf.Epsilon && Input.GetKeyDown(KeyCode.Space)|| 
        Mathf.Abs(moveDir.y) > Mathf.Epsilon && Input.GetKeyDown(KeyCode.Space) || 
        Input.GetKeyDown(KeyCode.Space))
        {
            
            animator.SetBool("IsJumping", true);
            animator.SetFloat("Horizontal", moveDir.x);
            animator.SetFloat("Vertical", moveDir.y);
        }
        else
        {
             animator.SetBool("IsJumping", false);
        }
    }
    
    private void OnRunning()
    {
        //bool runPressed = InputManager.GetInstance().GetRunPressed();
        if (Mathf.Abs(moveDir.x) > Mathf.Epsilon && Input.GetKey(KeyCode.LeftShift) || 
        Mathf.Abs(moveDir.y) > Mathf.Epsilon && Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    //STATES

    // private void UpdateIsGrounded()
    // {
    //     Bounds colliderBounds = coll.bounds;
    //     float colliderRadius = coll.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
    //     Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
    //     // Check if player is grounded
    //     Collider[] colliders = Physics.OverlapSphere(groundCheckPos, colliderRadius);
    //     // Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
    //     this.isGrounded = false;
    //     if (colliders.Length > 0)
    //     {
    //         for (int i = 0; i < colliders.Length; i++)
    //         {
    //             if (colliders[i] != coll)
    //             {
    //                 this.isGrounded = true;
    //                 break;
    //             }
    //         }
    //     }
    // }

    private bool UpdateIsGrounded()
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

