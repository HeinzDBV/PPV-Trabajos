using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float runSpeed = 2f;
    [SerializeField]
    private float jumpSpeed = 4f;
    private float moveDirection = 0f;

    public bool isInTheAir = true;

    private Rigidbody2D rb;
    private Animator animator;
    private CapsuleCollider2D capsuleCollider;



    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();   
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void OnMove(InputValue value)
    {
        
        moveDirection = value.Get<float>();
        Debug.Log(moveDirection);
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("AAA");
            if (capsuleCollider.IsTouchingLayers(
                LayerMask.GetMask("Ground"))
            ){
                // Saltar
                animator.SetBool("IsJumping", true);
                rb.velocity += new Vector2(0f, jumpSpeed);
                isInTheAir = true;
            }
        }
    }
    private void OnJump2()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("AAA");
            if (capsuleCollider.IsTouchingLayers(
                LayerMask.GetMask("Ground"))
            ){
                // Saltar
                animator.SetBool("IsJumping", true);
                rb.velocity += new Vector2(0f, jumpSpeed);
                isInTheAir = true;
            }
        }
    }
    private void Dashtp()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && moveDirection != 0)
        {
            transform.position += new Vector3(moveDirection * 2f,0,0);
        }
    }
    private void Update()
    {
        Run();
        FlipSprite();
        OnJump2();
        Dashtp();

        if (isInTheAir && (Mathf.Abs(rb.velocity.y) < Mathf.Epsilon))
        {
            // Estoy en el punto mas alto del salto
            Debug.Log("Entra");
            rb.gravityScale = 5f;
        }
    }

    private void FlipSprite()
    {
        if (Mathf.Abs(rb.velocity.x) > Mathf.Epsilon)
        {
            transform.localScale = new Vector3(
                Mathf.Sign(rb.velocity.x),
                1f,
                1f
            );
        }
    }

    private void Run()
    {
        if (moveDirection == 0f)
        {
            animator.SetBool("IsRunning", false);
        }
        else
        {
            animator.SetBool("IsRunning", true);
        }

        rb.velocity = new Vector2(
            runSpeed * moveDirection,
            rb.velocity.y
        );
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.transform.CompareTag("Platforms"))
        {
            // Finalizo el salto
            animator.SetBool("IsJumping", false);
            isInTheAir = false;
            rb.gravityScale = 1f;
        }
    }
}
