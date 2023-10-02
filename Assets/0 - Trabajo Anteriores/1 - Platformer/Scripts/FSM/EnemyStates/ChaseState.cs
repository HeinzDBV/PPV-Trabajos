using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyState
{
    private Transform _playerTransform;
    public ChaseState(EnemyController enemy, EnemySM stateMachine) : base(enemy, stateMachine)
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (enemy.IsInAttackRange)
        {
            Stop();
            Debug.Log("Attack");
            stateMachine.ChangeState(enemy.AttackState);
        }
        else if (!enemy.IsAggroed)
        {
            Stop();
            stateMachine.ChangeState(enemy.IdleState);
        }
        else
        {
            Chase();
        }
    }

    public void Chase()
    {
        Vector2 moveDirection = _playerTransform.position - enemy.transform.position;

        if (moveDirection.x > 0)
        {
            enemy.ChangeDirection(1);
        }
        else
        {
            enemy.ChangeDirection(-1);
        }

        if (enemy.IsThereEdge())
        {
            Stop();
        }
        else 
        {
            enemy.Move();
            enemy.ChangeAnimationState("Walking");
        }
    }

    public void Stop()
    {
        enemy.Stop();
        enemy.ChangeAnimationState("Idle");
    }

    public override void ExitState()
    {
        base.ExitState();
        enemy.Stop();
    }
}
