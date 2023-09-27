using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;
    public float lifeTime = 3f;
    public float distance = 10f;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<IDamageable>().Damage(damage);
            DestroyProjectile();
        }
    }
}
