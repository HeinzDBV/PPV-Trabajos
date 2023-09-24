using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    Animator animator;
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
        CurrentHealth = MaxHealth;
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
