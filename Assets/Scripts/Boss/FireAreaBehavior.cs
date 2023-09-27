using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAreaBehavior : MonoBehaviour
{
    public bool damaged = true;
    public float damage = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("FireAreaBehavior OnTriggerEnter2D");
        if (other.gameObject.CompareTag("Player") && damaged)
        {
            other.gameObject.GetComponent<IDamageable>().Damage(damage);
            damaged = false;
        }
    }
}
