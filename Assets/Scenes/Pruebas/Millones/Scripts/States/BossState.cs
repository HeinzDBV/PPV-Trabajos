using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState
{
    protected BossController boss;
    protected BossSM bossSM;
    protected BossData bossData;
    protected float startTime;

    public BossState(BossController boss, BossSM bossSM, BossData bossData)
    {
        this.boss = boss;
        this.bossSM = bossSM;
        this.bossData = bossData;
    }

    public virtual void Enter()
    {
        DoChecks();
        startTime = Time.time;
    }

    public virtual void Exit() { }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate() => DoChecks();

    public virtual void DoChecks() { }

}
