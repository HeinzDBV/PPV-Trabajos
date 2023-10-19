using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathState : BossState
{
    public float deathTime = 5f;
    private float deathTimeCounter = 0f;
    public BossDeathState(BossController boss, BossSM bossSM, BossData bossData) : base(boss, bossSM, bossData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        boss.ChangeAnimation("Death");
        Debug.Log("Death");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
}
