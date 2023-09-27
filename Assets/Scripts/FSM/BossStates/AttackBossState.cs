using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBossState : EnemyState
{
    private Transform _playerTransform;

    private float _timer = 3f;
    private float _timeBetweenShots = 2f;

    private float _exitTimer = 0;
    private float _timeTillExit = 3f;

    private float _bulletSpeed = 10f;

    public AttackBossState(BossController enemy, EnemySM stateMachine) : base(enemy, stateMachine)
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Enter Attack State");
        enemy.ChangeAnimationState("Idle");
        enemy.Stop();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (enemy.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !enemy.animator.IsInTransition(0) && enemy.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            enemy.ChangeAnimationState("Idle");
        }
        enemy.Stop();

        if (_timer > _timeBetweenShots)
        {
            _timer = 0;
            Shoot();
        }
        else
        {
            _timer += Time.deltaTime;
        }

        if (enemy.IsInAttackRange)
        {
            _exitTimer = 0;
        }
        else
        {
            _exitTimer += Time.deltaTime;

            if (_exitTimer > _timeTillExit)
            {
                stateMachine.ChangeState(enemy.ChaseState);
            }
        }
    }

    public void Shoot()
    {
        enemy.ChangeAnimationState("Attack");
        Vector2 dir = (_playerTransform.position - enemy.transform.position).normalized;
        enemy.ChangeDirection(dir.x > 0 ? 1 : -1);

        Rigidbody2D bullet = GameObject.Instantiate(enemy.bulletPrefab, enemy.transform.position, Quaternion.identity);
        bullet.velocity = new Vector2(dir.x * _bulletSpeed, 0);
        
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("Exit Attack State");
    }
}
