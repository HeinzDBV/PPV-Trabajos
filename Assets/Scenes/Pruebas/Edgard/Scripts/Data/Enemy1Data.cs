using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy1Data", menuName = "Enemy Data")]
public class Enemy1Data : ScriptableObject
{
    public float maxHealth = 50f;
    public float movementVelocity = 10f;
    public float attackDamage = 10f;
    public Enemy1ProjectileBehavior projectile;

}
