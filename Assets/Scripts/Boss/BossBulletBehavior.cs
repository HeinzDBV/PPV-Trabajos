using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletBehavior : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        damageable?.Damage(damage);
        SplashFire();
        DestroyProjectile();
    }

    public void SplashFire()
    {
        FireBehavior firePrefab = Resources.Load<FireBehavior>("Prefabs/Fire");

        for (int i = 0; i <= 8; i++)
        {
            FireBehavior fire = Instantiate(firePrefab, transform.position, Quaternion.identity);
            fire.rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * speed;
        }
    }
}
