using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1State
{
    protected Enemy1Controller Enemy1;
    protected Enemy1SM Enemy1SM;
    protected Enemy1Data Enemy1Data;
    protected float startTime;

    public Enemy1State(Enemy1Controller Enemy1, Enemy1SM Enemy1SM, Enemy1Data Enemy1Data)
    {
        this.Enemy1 = Enemy1;
        this.Enemy1SM = Enemy1SM;
        this.Enemy1Data = Enemy1Data;
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
