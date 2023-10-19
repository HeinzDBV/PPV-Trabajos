using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(CapsuleCollider))]
public class EnemyController : MonoBehaviour, IDamageable
{
    #region States
    public IdleState IdleState;
    public FollowState FollowState;
    private State currentState;
    #endregion

    #region Parameters
    public Transform Player;
    public float DistanceToFollow = 4f;
    public float DistanceToAttack = 3f;
    public float Speed = 1f;
    public GameObject firePrefab;
    public Transform FirePoint;
    public float CoolDownTime = 1.0f;
    #endregion

    //public int Hit_Points

    #region Readonly Properties
    public Rigidbody rb { private set; get; }
    public Animator animator { private set; get; }
    public Enemy1HealthSlider Enemy1HealthSlider { get; private set; }
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    #endregion



    private void Awake()
    {
        IdleState = new IdleState(this);
        FollowState = new FollowState(this);

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        // Seteamos el estado inicial
        currentState = IdleState;
    }

    private void Start()
    {
        currentState.OnStart();
        MaxHealth = 20f;
        CurrentHealth = MaxHealth;
        Enemy1HealthSlider = GetComponentInChildren<Enemy1HealthSlider>();
        Enemy1HealthSlider.slider.maxValue = MaxHealth;
        Enemy1HealthSlider.slider.value = CurrentHealth;
    }

    private void Update()
    {
        foreach (var transition in currentState.Transitions)
        {
            if (transition.IsValid())
            {
                // Ejecutar Transicion
                currentState.OnFinish();
                currentState = transition.GetNextState();
                currentState.OnStart();
                break;
            }
        }
        currentState.OnUpdate();
    }

    public void Fire()
    {
        GameObject fireball = Instantiate(firePrefab, FirePoint.position, Quaternion.identity);
        fireball.GetComponent<FireMovement>().Direction =
            Player.position - FirePoint.position;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        Debug.Log("Enemy1 took " + damage + " damage. Current health: " + CurrentHealth);
        Enemy1HealthSlider.slider.value = CurrentHealth;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
