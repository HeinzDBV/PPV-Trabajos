using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossState
{
    private float idleTime = 3f;
    private float idleTimeCounter = 0f;
    private int direction = 1;
    public BossIdleState(BossController boss, BossSM bossSM, BossData bossData) : base(boss, bossSM, bossData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        boss.ActivateShield();
        boss.Animator.SetBool("IsWalking", true);
        direction *= -1;
        Debug.Log("Idle");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        boss.Move(new Vector2(boss.CurrentDirection.y * direction, -boss.CurrentDirection.x));

        idleTimeCounter += Time.deltaTime;
        if (idleTimeCounter >= idleTime)
        {
            idleTimeCounter = 0;
            bossSM.ChangeState(boss.AttackState);
        }
    }


    public override void Exit()
    {
        base.Exit();
        boss.Animator.SetBool("IsWalking", false);
    }

}
