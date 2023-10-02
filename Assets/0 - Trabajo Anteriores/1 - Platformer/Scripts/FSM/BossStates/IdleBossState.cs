using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBossState : EnemyState
{
    public int attack = 0;

    public float attackTimer = 0f;
    public float attackCooldown = 3f;
    public Transform _playerTransform;

    public IdleBossState(BossController boss, EnemySM stateMachine) : base(boss, stateMachine)
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Enter Idle State");
    }

    public override void FrameUpdate()
    {
        LookAtPlayer();

        if (!(boss.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) && boss.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            boss.ChangeAnimationState("Idle");
        }

        if (attackTimer > attackCooldown)
        {
            attackTimer = 0;
            attack = Random.Range(0, 3);
            Attack(attack);
        }
        else
        {
            attackTimer += Time.deltaTime;
        }
    }

    public void LookAtPlayer()
    {
        boss.LookAtTarget(_playerTransform);
    }

    public void Attack(int attackType)
    {
        if (attackType == 0)
        {
            Debug.Log("Attack 1");
            boss.ChangeAnimationState("Attack1");
            Shoot(boss.point1, attackType);
        }
        else if (attackType == 1)
        {
            Debug.Log("Attack 2");
            boss.ChangeAnimationState("Attack2");
            Shoot(boss.point2, attackType);
        }
        else if (attackType == 2)
        {
            Debug.Log("Attack 3");
            boss.ChangeAnimationState("Attack3");
            Shoot(boss.point3, attackType);
        }
    }

    public void Shoot(Transform point, int attackType)
    {
        Rigidbody2D bullet = GameObject.Instantiate(boss.bulletPrefab, point.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        bullet.velocity = new Vector2(boss.direction * boss.bulletSpeed, 0);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
