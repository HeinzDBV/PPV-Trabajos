using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy1Controller : MonoBehaviour, IDamageable
{
    #region State Variables

    public Enemy1SM Enemy1SM { get; private set; }
    public Enemy1SleepState SleepState { get; private set; }
    public Enemy1AwakenState AwakenState { get; private set; }
    public Enemy1HurtState HurtState { get; private set; }
    public Enemy1IdleState IdleState { get; private set; }
    public Enemy1DeathState DeathState { get; private set; }
    public Enemy1AttackState AttackState { get; private set; }

    [SerializeField] private Enemy1Data Enemy1Data;

    #endregion

    #region Components

    public Animator Animator { get; private set; }
    public Rigidbody RB { get; private set; }
    public Vector3 CurrentVelocity { get; private set; }
    public Vector3 CurrentDirection { get; private set; }
    public Transform Player { get; private set; }

    #endregion

    #region Other Scripts Variables
    public Enemy1HealthSlider Enemy1HealthSlider { get; private set; }

    public Enemy1TriggerAreaBehavior Enemy1TriggerAreaBehavior { get; private set; }
    public AttackAreaBehavior AttackArea { get; private set; }
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public bool IsVulnerable { get; set; }

    #endregion

    #region Events
    public static event Action OnEnemy1Death;
    #endregion
    void Awake()
    {
        Enemy1SM = new Enemy1SM();

        SleepState = new Enemy1SleepState(this, Enemy1SM, Enemy1Data);
        AwakenState = new Enemy1AwakenState(this, Enemy1SM, Enemy1Data);
        IdleState = new Enemy1IdleState(this, Enemy1SM, Enemy1Data);
        HurtState = new Enemy1HurtState(this, Enemy1SM, Enemy1Data);
        DeathState = new Enemy1DeathState(this, Enemy1SM, Enemy1Data);
        AttackState = new Enemy1AttackState(this, Enemy1SM, Enemy1Data);
    }

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        RB = GetComponent<Rigidbody>();
        Enemy1TriggerAreaBehavior = GetComponentInChildren<Enemy1TriggerAreaBehavior>();
        Enemy1HealthSlider = GetComponentInChildren<Enemy1HealthSlider>();
        Player = GameObject.FindWithTag("Player").transform;

        MaxHealth = Enemy1Data.maxHealth;
        CurrentHealth = MaxHealth;

        Enemy1HealthSlider.slider.maxValue = MaxHealth;
        Enemy1HealthSlider.slider.value = CurrentHealth;

        Enemy1SM.Initialize(SleepState);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentVelocity = RB.velocity;
        LookAtPlayer();
        Enemy1SM.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        Enemy1SM.CurrentState.PhysicsUpdate();
    }

    public void ChangeAnimation(string aninName)
    {
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName(aninName)) return;

        Animator.Play(aninName);
    }

    public void LookAtPlayer()
    {
        Vector3 lookAtPosition = Player.position - transform.position;
        lookAtPosition.y = 0;
        lookAtPosition.Normalize();
        CurrentDirection = lookAtPosition;
        Debug.DrawRay(transform.position, lookAtPosition, Color.red);

        Animator.SetFloat("Horizontal", lookAtPosition.x);
        Animator.SetFloat("Vertical", lookAtPosition.z);
    }

    public void Move(Vector2 moveDirection)
    {
        RB.MovePosition(RB.position + Enemy1Data.movementVelocity * Time.deltaTime * new Vector3(moveDirection.x, 0, moveDirection.y));
    }

    public void TakeDamage(float damage)
    {
        if (!IsVulnerable) return;

        CurrentHealth -= damage;
        Enemy1HealthSlider.slider.value = CurrentHealth;

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
        }
        else
        {
            Enemy1SM.ChangeState(HurtState);
        }
    }

    public void Die()
    {
        Enemy1SM.ChangeState(DeathState);
        OnEnemy1Death?.Invoke();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
