using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossState
{
    private float idleTime;
    private float idleTimeCounter;
    public BossIdleState(BossController boss, BossSM bossSM, BossData bossData) : base(boss, bossSM, bossData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Idle");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        boss.LookAtPlayer();
        boss.Move(boss.CurrentDirection);
    }

    

    
}
