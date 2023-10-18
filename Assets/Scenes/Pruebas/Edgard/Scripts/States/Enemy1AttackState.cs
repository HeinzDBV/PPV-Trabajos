using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1AttackState : Enemy1State
{
    public float attackTimer = 0f;
    public int attackCount = 0;
    public float attackRange = 135f;

    public Enemy1AttackState(Enemy1Controller Enemy1, Enemy1SM Enemy1SM, Enemy1Data Enemy1Data) : base(Enemy1, Enemy1SM, Enemy1Data)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Attack();
    }

    public void Attack()
    {
            NormalAttack();
    }


    public void NormalAttack()
    {
        Enemy1.ChangeAnimation("Attack");
        attackCount++;
        ThrowProjectile(Enemy1.CurrentDirection);
    }

    public void ThrowProjectile(Vector3 direction)
    {
        Enemy1ProjectileBehavior projectile = GameObject.Instantiate(Enemy1Data.projectile, Enemy1.transform.position, Quaternion.identity);
        projectile.Initialize(direction);
    }
}
