using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBossState : EnemyState
{
    public HurtBossState(BossController boss, EnemySM stateMachine) : base(boss, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        boss.ChangeAnimationState("Hurt");
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (boss.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            stateMachine.ChangeState(boss.IdleState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
