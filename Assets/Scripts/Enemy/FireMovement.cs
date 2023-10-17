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
    private float timeToDestroy = 3f;

    private Rigidbody rb;
    private float timer = 0f;
    public float damage = 1f;
    public Transform Player;

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

    private void OnCollisionEnter(Collision other)
    {
        // Hay una colision
        // TODO: Falta hacerle danho al jugador
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Le hace danho al jugador");
        }
        Debug.Log("Se destruye");
        FireDestroy();

    }
}
