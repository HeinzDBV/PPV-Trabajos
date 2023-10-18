using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(SphereCollider))]
public class FireMovement : MonoBehaviour
{
    public Vector3 Direction;

    [SerializeField]
    private float Speed = 5f;
    [SerializeField]
    private float timeToDestroy = 5f;

    private Rigidbody rb;
    private float timer = 0f;
    public float damage = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Start()
    {

    }

    private void Update()
    {
        rb.velocity = Direction.normalized * Speed;

        timer += Time.deltaTime;
        if (timer >= timeToDestroy)
        {
            FireDestroy();
        }
    }

    private void FireDestroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<IDamageable>().TakeDamage(damage);
            Debug.Log(other.gameObject.GetComponent<IDamageable>().CurrentHealth);
            FireDestroy();
        }
    }
}
