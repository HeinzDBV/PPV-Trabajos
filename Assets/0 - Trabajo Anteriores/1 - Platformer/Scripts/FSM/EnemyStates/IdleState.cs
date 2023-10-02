using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyState
{
    public bool idle = true;

    public IdleState(EnemyController enemy, EnemySM stateMachine) : base(enemy, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.StartCoroutine(IdleTimer(2f));
    }

    public override void FrameUpdate()
    {
        if (enemy.IsAggroed)
        {
            stateMachine.ChangeState(enemy.ChaseState);
        }

        if (idle)
        {
            Idle();
        }
        else
        {
            Walking();
        }
    }

    public void Idle()
    {
        idle = true;
        enemy.Stop();
        enemy.ChangeAnimationState("Idle");
    }

    public void Walking()
    {
        idle = false;
        enemy.Move();
        enemy.CheckEdge();
        enemy.ChangeAnimationState("Walking");
    }

    public IEnumerator IdleTimer(float time)
    {
        yield return new WaitForSeconds(time);
        if (idle)
        {
            idle = false;
            enemy.StartCoroutine(IdleTimer(Random.Range(4f, 8f)));
        }
        else
        {
            idle = true;
            enemy.StartCoroutine(IdleTimer(Random.Range(2f, 4f)));
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        enemy.StopAllCoroutines();
        Idle();
    }

}
