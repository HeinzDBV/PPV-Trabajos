using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepState : EnemyState
{
    public SleepState(BossController boss, EnemySM stateMachine) : base(boss, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Sleeping");
    }

    public override void OnTriggerEnter(Collider2D other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.CompareTag("Player"))
        {
            stateMachine.ChangeState(boss.IdleState);
        }
    }
}
