using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyState
{
    public Vector3 targetPosition;
    public Vector3 direction;
    
    public IdleState(EnemyController enemy, EnemySM stateMachine) : base(enemy, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
