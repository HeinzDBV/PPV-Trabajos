using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1IdleState : Enemy1State
{
    private float idleTime = 3f;
    private float idleTimeCounter = 0f;
    private int direction = 1;
    public Enemy1IdleState(Enemy1Controller Enemy1, Enemy1SM Enemy1SM, Enemy1Data Enemy1Data) : base(Enemy1, Enemy1SM, Enemy1Data)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Enemy1.Animator.SetBool("IsWalking", true);
        direction *= -1;
        Debug.Log("Idle");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Enemy1.Move(new Vector2(Enemy1.CurrentDirection.y * direction, -Enemy1.CurrentDirection.x));

        idleTimeCounter += Time.deltaTime;
        if (idleTimeCounter >= idleTime)
        {
            idleTimeCounter = 0;
            Enemy1SM.ChangeState(Enemy1.AttackState);
        }
    }


    public override void Exit()
    {
        base.Exit();
        Enemy1.Animator.SetBool("IsWalking", false);
    }

}
