using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehavior : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent<IDamageable>(out IDamageable damageable);
        damageable?.TakeDamage(10000f);
    }
}
