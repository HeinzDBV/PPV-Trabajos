using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAwakenState : BossState
{
    public BossAwakenState(BossController boss, BossSM bossSM, BossData bossData) : base(boss, bossSM, bossData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Awakening");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        bossSM.ChangeState(boss.IdleState);
    }
}
