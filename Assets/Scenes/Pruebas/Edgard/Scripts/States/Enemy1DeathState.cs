using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1DeathState : Enemy1State
{
    public float deathTime = 5f;
    private float deathTimeCounter = 0f;
    public Enemy1DeathState(Enemy1Controller Enemy1, Enemy1SM Enemy1SM, Enemy1Data Enemy1Data) : base(Enemy1, Enemy1SM, Enemy1Data)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Enemy1.ChangeAnimation("Death");
        Debug.Log("Death");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        deathTimeCounter += Time.deltaTime;
        if (deathTimeCounter >= deathTime)
        {
            deathTimeCounter = 0;
            Enemy1.Destroy();
        }
    }
}
