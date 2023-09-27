using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    #region Components
    public Animator animator;
    public Rigidbody2D rb;
    public Rigidbody2D bulletPrefab;
    public EnemyHealth enemyHealth;

    public Transform point1;
    public Transform point2;
    public Transform point3;
    public LayerMask enemy;
    #endregion
    private string currentState;

    [SerializeField]
    public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }
    public float bulletSpeed = 10f;

    #region StateMachineVariables
    public EnemySM StateMachine { get; set; }
    public EnemyState IdleState { get; set; }
    public EnemyState AttackState { get; set; }
    public EnemyState DeathState { get; set; }
    public EnemyState ChaseState { get; set; }
    public EnemyState HurtState { get; set; }
    public EnemyState SleepState { get; set; }
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
        SleepState = new SleepState(this, StateMachine);
        IdleState = new IdleBossState(this, StateMachine);
        AttackState = new AttackBossState(this, StateMachine);
        DeathState = new DeathBossState(this, StateMachine);
        HurtState = new HurtBossState(this, StateMachine);

        StateMachine.Initialize(SleepState);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bulletPrefab = Resources.Load<Rigidbody2D>("Prefabs/BossBullet");
        enemyHealth.SetMaxHealth(MaxHealth);
        
        currentState = "Idle";
        CurrentHealth = MaxHealth;
    }

    public void Move()
    {
        rb.velocity = new Vector2(Speed * direction, rb.velocity.y);
        
        if (direction == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
            enemyHealth.ChangeDirection(1);
        }
        else if (direction == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            enemyHealth.ChangeDirection(-1);
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

    public void LookAtTarget(Transform target)
    {
        if (target.position.x > transform.position.x)
        {
            direction = 1;
            transform.localScale = new Vector3(1, 1, 1);
            enemyHealth.ChangeDirection(1);
        }
        else if (target.position.x < transform.position.x)
        {
            direction = -1;
            transform.localScale = new Vector3(-1, 1, 1);
            enemyHealth.ChangeDirection(-1);
        }
    }

    public void Flip()
    {
        direction *= -1;
        transform.localScale = new Vector3(transform.localScale.x * direction, 1, 1);
    }

    public void Flip(int value)
    {
        direction = value;
        transform.localScale = new Vector3(transform.localScale.x * direction, 1, 1);
    }

    public void ChangeDirection(int value)
    {
        if (value == 1)
        {
            direction = 1;
            transform.localScale = new Vector3(1, 1, 1);
            enemyHealth.ChangeDirection(1);
        }
        else if (value == -1)
        {
            direction = -1;
            transform.localScale = new Vector3(-1, 1, 1);
            enemyHealth.ChangeDirection(-1);
        }
    }

    public void ChangeDirection()
    {
        if (transform.localScale.x == 1)
        {
            direction = -1;
            enemyHealth.ChangeDirection(-1);
        }
        else if (transform.localScale.x == -1)
        {
            direction = 1;
            enemyHealth.ChangeDirection(1);
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
        enemyHealth.SetHealth(CurrentHealth);
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

    public void OnTriggerEnter2DFunc(Collider2D other)
    {
        StateMachine.CurrentState.OnTriggerEnter(other);
    }
}
