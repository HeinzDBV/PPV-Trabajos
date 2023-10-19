using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1HurtState : Enemy1State
{
    public float hurtTime = 1f;
    // private float hurtTimeCounter = 0f;

    public Enemy1HurtState(Enemy1Controller Enemy1, Enemy1SM Enemy1SM, Enemy1Data Enemy1Data) : base(Enemy1, Enemy1SM, Enemy1Data)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Enemy1.ChangeAnimation("Enemy1 Hurt");
        Enemy1.IsVulnerable = false;
        Debug.Log("Enemy1 Hurt");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void Exit()
    {
        base.Exit();
        Enemy1.IsVulnerable = true;
    }
}
