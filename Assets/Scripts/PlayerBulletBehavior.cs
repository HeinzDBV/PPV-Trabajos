using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehavior : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 30f;
    public float lifeTime = 5f;
    public float distance = 10f;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            return;
        }
        Debug.Log("Hit: " + other);
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        damageable?.Damage(damage);
        DestroyProjectile();
    }
}
