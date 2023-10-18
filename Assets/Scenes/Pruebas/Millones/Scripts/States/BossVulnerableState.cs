using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVulnerableState : BossState
{
    private readonly float vulnerableTime;
    public float vulnerableTimeCounter = 0f;

    public BossVulnerableState(BossController boss, BossSM bossSM, BossData bossData) : base(boss, bossSM, bossData)
    {
        vulnerableTime = bossData.vulnerableTime;
    }

    public override void Enter()
    {
        base.Enter();
        boss.DeactivateShield();
        Debug.Log("Vulnerable");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        vulnerableTimeCounter += Time.deltaTime;
        if (vulnerableTimeCounter >= vulnerableTime)
        {
            vulnerableTimeCounter = 0;
            bossSM.ChangeState(boss.IdleState);
        }
    }
}
