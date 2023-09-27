using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour , IDamageable
{
    public Animator anim;
    public Rigidbody2D rb;

    [Header("Movement Info")]
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 12;

    private bool canMove = true;
    private bool canDoubleJump;
    private bool canWallSlide;
    private bool isWallSliding;
    public PlayerHealth playerHealth;
    


    [Header("Collision Info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private bool isGrounded;

    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private bool isWallDetected;


    private bool facingRight = true;
    private float movingInput;

    public float MaxHealth { get; set; } = 100;
    public float CurrentHealth { get; set; }

    void Start()
    {
        CurrentHealth = MaxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        checkInput();
        CollisionCheck();
        AnimatorController();
        FlipController();
    }

    private void JumpButton()
    {
        if (isGrounded)
            Jump();
        else if (canDoubleJump)
        {
            canDoubleJump = false;
            Jump();
            
        }
        else if(isWallSliding){
            canDoubleJump = true;
            Jump();
        }
        Debug.Log("isGrounded: ");
        Debug.Log(isGrounded);
        Debug.Log("canDoubleJump: ");
        Debug.Log(canDoubleJump);
    }


    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void FixedUpdate()
    {
        if(isGrounded){
            canDoubleJump = true;
        }

        if(isWallDetected && canWallSlide){
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.1f);
        }
        else{
            isWallSliding = false;
            Move();
        }
        
    }

    private void checkInput(){

        if (Input.GetKeyDown(KeyCode.UpArrow))
            JumpButton();
            if(canMove)
             movingInput = Input.GetAxisRaw("Horizontal");
    }

    private void Move()
    {
        if (canMove)
        {
            rb.velocity = new Vector2(movingInput * speed, rb.velocity.y);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void FlipController()
    {
        if(isGrounded && isWallDetected ){
            if(facingRight && movingInput<0){
                Flip();
            }
            else if(!facingRight && movingInput>0){
                Flip();
            }
        }
        
        if (rb.velocity.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (rb.velocity.x < 0 && facingRight)
        {
            Flip();
        }
    }

    private void OnTeleport(InputValue value)
    {
        if (value.isPressed && rb.velocity.x >0)
        {
            transform.position = new Vector2(rb.position.x + 2f, rb.position.y);
        }
        else if(value.isPressed && rb.velocity.x < 0){
            transform.position = new Vector2(rb.position.x - 2f, rb.position.y);
        }
    }


    private void AnimatorController()

    {
        bool isMoving = rb.velocity.x != 0;
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("IsGrounded", isGrounded);
        anim.SetBool("IsMoving", isMoving);
        anim.SetBool("IsWallSliding", isWallSliding);
    }

    private void CollisionCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isWallDetected = Physics2D.Raycast(wallCheck.position, Vector2.right,wallCheckDistance, whatIsGround);


      
        if(!isGrounded && rb.velocity.y < 0)
            canWallSlide = true;
        else{
            canWallSlide = false;
        }  
    }
    

/*Para verlo en Unity*/
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));

    }

    public void Damage(float damage)
    {
        CurrentHealth -= damage;
        playerHealth.SetHealth(CurrentHealth);
        if(CurrentHealth <= 0)
            Die();
    }

    public void Die()
    {
        
    }
}
