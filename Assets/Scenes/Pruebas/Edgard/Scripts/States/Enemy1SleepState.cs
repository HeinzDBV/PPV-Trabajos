using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1SleepState : Enemy1State
{
    private bool playerHasEntered;
    public Enemy1SleepState(Enemy1Controller Enemy1, Enemy1SM Enemy1SM, Enemy1Data Enemy1Data) : base(Enemy1, Enemy1SM, Enemy1Data)
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
        playerHasEntered = Enemy1.Enemy1TriggerAreaBehavior.playerHasEntered;

        if (playerHasEntered) 
        {
            Enemy1SM.ChangeState(Enemy1.AwakenState);
        }
    }
}
