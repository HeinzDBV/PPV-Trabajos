using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHurtState : BossState
{
    public float hurtTime = 1f;
    private float hurtTimeCounter = 0f;

    public BossHurtState(BossController boss, BossSM bossSM, BossData bossData) : base(boss, bossSM, bossData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        boss.ChangeAnimation("Hurt");
        boss.IsVulnerable = false;
        Debug.Log("Hurt");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        hurtTimeCounter += Time.deltaTime;
        if (hurtTimeCounter >= hurtTime)
        {
            boss.VulnerableState.vulnerableTimeCounter += hurtTimeCounter;
            hurtTimeCounter = 0;
            bossSM.ChangeState(boss.VulnerableState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        boss.IsVulnerable = true;
    }
}
