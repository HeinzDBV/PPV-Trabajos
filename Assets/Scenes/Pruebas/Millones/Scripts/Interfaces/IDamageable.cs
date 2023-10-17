using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    
    void TakeDamage(float damage);
    void Die();
}
