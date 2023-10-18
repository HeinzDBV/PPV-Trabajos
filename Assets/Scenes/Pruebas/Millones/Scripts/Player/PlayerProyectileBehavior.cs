using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProyectileBehavior : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 5f;
    public float lifeTime = 5f;
    public float lifeTimeCounter = 0f;
    public Vector3 direction;

    // Start is called before the first frame update
    public void Initialize(Vector3 direction)
    {
        this.direction = direction;
        transform.rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + 90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimeCounter += Time.deltaTime;
        if (lifeTimeCounter >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<BossController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
