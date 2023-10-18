using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossState
{
    public float attackTimer = 0f;
    public int attackCount = 0;
    public int attacksUntilSpecial = 2;
    public int projectilesPerAttack = 7;
    public float attackRange = 135f;

    public BossAttackState(BossController boss, BossSM bossSM, BossData bossData) : base(boss, bossSM, bossData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Attack();
    }

    public void Attack()
    {
        if (attackCount >= attacksUntilSpecial)
        {
            SpecialAttack();
            boss.BossSM.ChangeState(boss.VulnerableState);
        }
        else 
        {
            NormalAttack();
            boss.BossSM.ChangeState(boss.IdleState);
        }

    }

    public void SpecialAttack()
    {
        boss.ChangeAnimation("Special2");
        attackCount = 0;

        float angle = attackRange / (projectilesPerAttack + 1);
        Debug.Log(angle);
        Vector3 dir = Quaternion.AngleAxis(-attackRange / 2, Vector3.up) * boss.CurrentDirection;
        
        for (int i = 1; i <= projectilesPerAttack; i++)
        {
            dir = Quaternion.AngleAxis(angle, Vector3.up) * dir;
            ThrowProjectile(dir);
        }
    }

    public void NormalAttack()
    {
        boss.ChangeAnimation("Special1");
        attackCount++;
        ThrowProjectile(boss.CurrentDirection);
    }

    public void ThrowProjectile(Vector3 direction)
    {
        BossProjectileBehavior projectile = GameObject.Instantiate(bossData.projectile, boss.transform.position, Quaternion.identity);
        projectile.Initialize(direction);
    }
}
