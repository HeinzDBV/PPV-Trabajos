using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossState
{
    public float attackTimer;
    public int attackCount;

    public BossAttackState(BossController boss, BossSM bossSM, BossData bossData) : base(boss, bossSM, bossData)
    {
    }


    public void Attack()
    {
        if (attackCount >= 3)
        {
            SpecialAttack();
        }
        else 
        {
            NormalAttack();
        }
    }

    public void SpecialAttack()
    {
        boss.ChangeAnimation("Specail2");
        attackCount = 0;
    }

    public void NormalAttack()
    {
        boss.ChangeAnimation("Special1");
        attackCount++;
    }

    public void ThrowProjectile(Vector2 direction)
    {
        BossProjectileBehavior projectile = GameObject.Instantiate(bossData.projectile, boss.transform.position, Quaternion.identity);
        projectile.Initialize(direction);
    }
}
