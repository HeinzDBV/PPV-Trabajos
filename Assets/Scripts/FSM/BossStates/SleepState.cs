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
        //boss.ChangeAnimationState("Sleep");
    }
}
