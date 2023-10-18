using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1AwakenState : Enemy1State
{
    public Enemy1AwakenState(Enemy1Controller Enemy1, Enemy1SM Enemy1SM, Enemy1Data Enemy1Data) : base(Enemy1, Enemy1SM, Enemy1Data)
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
        Enemy1SM.ChangeState(Enemy1.IdleState);
    }
}
