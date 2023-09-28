using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBossState : EnemyState
{
    private float deathTimer = 0.0f;
    private float deathTime = 10.0f;
    public DeathBossState(BossController boss, EnemySM stateMachine) : base(boss, stateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        boss.ChangeAnimationState("Death");
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        deathTimer += Time.deltaTime;
        if (deathTimer >= deathTime)
        {
            Die();
        }
    }

    public override void ExitState()
    {
        // Do nothing
    }

    public void Die()
    {
        GameObject.Destroy(boss.gameObject);
    }
}
