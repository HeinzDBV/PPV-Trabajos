using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossController : MonoBehaviour, IDamageable
{
    #region State Variables

    public BossSM BossSM { get; private set; }
    public BossSleepState SleepState { get; private set; }
    public BossAwakenState AwakenState { get; private set; }
    public BossHurtState HurtState { get; private set; }
    public BossIdleState IdleState { get; private set; }
    public BossDeathState DeathState { get; private set; }
    public BossAttackState AttackState { get; private set; }
    public BossVulnerableState VulnerableState { get; private set; }

    [SerializeField] private BossData bossData;

    #endregion

    #region Components

    public Animator Animator { get; private set; }
    public Rigidbody RB { get; private set; }
    public Vector3 CurrentVelocity { get; private set; }
    public Vector3 CurrentDirection { get; private set; }
    public Transform Player { get; private set; }

    #endregion

    #region Other Scripts Variables

    public BossTriggerAreaBehavior BossTriggerAreaBehavior { get; private set; }
    public BossShieldBehavior BossShield { get; private set; }
    public AttackAreaBehavior AttackArea { get; private set; }
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public bool IsVulnerable { get; set; }

    #endregion

    #region Events
    public static event Action OnBossDeath;
    #endregion
    void Awake()
    {
        BossSM = new BossSM();

        SleepState = new BossSleepState(this, BossSM, bossData);
        AwakenState = new BossAwakenState(this, BossSM, bossData);
        IdleState = new BossIdleState(this, BossSM, bossData);
        HurtState = new BossHurtState(this, BossSM, bossData);
        DeathState = new BossDeathState(this, BossSM, bossData);
        AttackState = new BossAttackState(this, BossSM, bossData);
        VulnerableState = new BossVulnerableState(this, BossSM, bossData);
    }

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        RB = GetComponent<Rigidbody>();
        BossTriggerAreaBehavior = GetComponentInChildren<BossTriggerAreaBehavior>();
        BossShield = GetComponentInChildren<BossShieldBehavior>();
        Player = GameObject.FindWithTag("Player").transform;
        DeactivateShield();

        MaxHealth = bossData.maxHealth;
        CurrentHealth = MaxHealth;

        BossSM.Initialize(SleepState);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentVelocity = RB.velocity;
        LookAtPlayer();
        BossSM.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        BossSM.CurrentState.PhysicsUpdate();
    }

    public void ChangeAnimation(string aninName)
    {
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName(aninName)) return;

        Animator.Play(aninName);
    }

    public void ActivateShield()
    {
        BossShield.ActivateShield();
        IsVulnerable = false;
    }

    public void DeactivateShield()
    {
        BossShield.DeactivateShield();
        IsVulnerable = true;
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
        RB.MovePosition(RB.position + bossData.movementVelocity * Time.deltaTime * new Vector3(moveDirection.x, 0, moveDirection.y));
    }

    public void TakeDamage(float damage)
    {
        if (!IsVulnerable) return;

        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
        }
        else
        {
            BossSM.ChangeState(HurtState);
        }
    }

    public void Die()
    {
        BossSM.ChangeState(DeathState);
        OnBossDeath?.Invoke();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
