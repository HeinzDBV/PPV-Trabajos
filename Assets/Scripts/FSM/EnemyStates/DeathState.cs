using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : EnemyState
{
    public DeathState(EnemyController enemy, EnemySM stateMachine) : base(enemy, stateMachine)
    {
    }

    public override void EnterState()
    {
        enemy.Die();
    }

    public override void FrameUpdate()
    {
        // Do nothing
    }

    public override void ExitState()
    {
        // Do nothing
    }
}
