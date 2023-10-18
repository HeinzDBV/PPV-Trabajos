using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossData", menuName = "Boss Data")]
public class BossData : ScriptableObject
{
    public float maxHealth = 100f;
    public float movementVelocity = 10f;
    public float attackDamage = 10f;
    public BossProjectileBehavior projectile;
    public float vulnerableTime = 5f;
}
