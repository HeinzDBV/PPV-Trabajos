using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShieldBehavior : MonoBehaviour
{
    public bool ShieldActive { get; set; }

    public void ActivateShield()
    {
        gameObject.SetActive(true);
        ShieldActive = true;
    }

    public void DeactivateShield()
    {
        gameObject.SetActive(false);
        ShieldActive = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<IDamageable>().TakeDamage(5);
        }
    }
}
