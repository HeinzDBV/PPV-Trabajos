using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSleepState : BossState
{
    private bool playerHasEntered;
    public BossSleepState(BossController boss, BossSM bossSM, BossData bossData) : base(boss, bossSM, bossData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Sleeping");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        playerHasEntered = boss.BossTriggerAreaBehavior.playerHasEntered;

        if (playerHasEntered) 
        {
            bossSM.ChangeState(boss.AwakenState);
        }
    }
}
