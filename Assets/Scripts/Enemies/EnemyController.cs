using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    #region Components
    public Animator animator;
    public Rigidbody2D rb;
    public Transform groundDetection;
    #endregion
    private string currentState;

    [SerializeField]
    public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }

    #region StateMachineVariables
    public EnemySM StateMachine { get; set; }
    public EnemyState IdleState { get; set; }
    public EnemyState AttackState { get; set; }
    public EnemyState DeathState { get; set; }
    public EnemyState ChaseState { get; set; }
    public EnemyState HurtState { get; set; }
    #endregion

    #region IdleVariables
    public float Speed = 5f;
    public float direction = 1f;
    #endregion

    void Awake()
    {
        StateMachine = new EnemySM();
        IdleState = new IdleState(this, StateMachine);
        AttackState = new AttackState(this, StateMachine);
        DeathState = new DeathState(this, StateMachine);
        ChaseState = new ChaseState(this, StateMachine);
        HurtState = new HurtState(this, StateMachine);

        StateMachine.Initialize(IdleState);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentState = "Idle";
        rb = GetComponent<Rigidbody2D>();
        groundDetection = transform.Find("GroundCheck");
        
        CurrentHealth = MaxHealth;
    }

    public void Move()
    {
        rb.velocity = new Vector2(Speed * direction, rb.velocity.y);
        
        if (direction == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Stop()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    public void IsThereEdge()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));
        
        Debug.Log(groundInfo.collider);
        if (!groundInfo.collider)
        {
            // Change direction when no ground is detected
            ChangeDirection();
            Debug.Log("No ground");
        }

    }

    public void ChangeDirection()
    {
        if (transform.localScale.x == 1)
        {
            direction = -1;
        }
        else if (transform.localScale.x == -1)
        {
            direction = 1;
        }
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.currentState.FrameUpdate();
    }

    void FixedUpdate()
    {
        StateMachine.currentState.PhysicsUpdate();
    }

    public void Damage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        
    }
}
