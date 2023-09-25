using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable, ITriggerCheckable
{
    #region Components
    public Animator animator;
    public Rigidbody2D rb;
    public Transform groundDetection;
    public Rigidbody2D bulletPrefab;
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
    public bool IsAggroed { get; set; }
    public bool IsInAttackRange { get; set; }

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
        bulletPrefab = Resources.Load<Rigidbody2D>("Prefabs/EnemyBullet");
        
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

    public void Move(int value)
    {
        rb.velocity = new Vector2(Speed * value, rb.velocity.y);
    }

    public void Stop()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    public void CheckEdge()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));
        
        if (!groundInfo.collider)
        {
            // Change direction when no ground is detected
            ChangeDirection();
        }

    }

    public bool IsThereEdge()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));
        
        if (!groundInfo.collider)
        {
            // Change direction when no ground is detected
            return true;
        }

        return false;
    }

    public void ChangeDirection(int value)
    {
        if (value == 1)
        {
            direction = 1;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (value == -1)
        {
            direction = -1;
            transform.localScale = new Vector3(-1, 1, 1);
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
        StateMachine.CurrentState.FrameUpdate();
    }

    void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void Damage(float damage)
    {
        CurrentHealth -= damage;
        StateMachine.ChangeState(HurtState);
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        StateMachine.ChangeState(DeathState);
    }

    public void SetAggroed(bool value)
    {
        IsAggroed = value;
    }

    public void SetInAttackRange(bool value)
    {
        IsInAttackRange = value;
    }
}
