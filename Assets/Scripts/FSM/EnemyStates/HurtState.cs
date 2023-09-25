using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : EnemyState
{
    public HurtState(EnemyController enemy, EnemySM stateMachine) : base(enemy, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.ChangeAnimationState("Hurt");
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (enemy.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            stateMachine.ChangeState(enemy.IdleState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
