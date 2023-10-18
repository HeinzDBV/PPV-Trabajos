using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileBehavior : MonoBehaviour
{
    public Animator Animator;
    public float timeToDestroy = 2f;
    public float timer = 0f;
    public float damage = 2f;
    public float speed = 5f;
    public Vector3 direction;
    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Move();
        }

        if (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            if (Animator.GetCurrentAnimatorStateInfo(0).IsName("Creacion"))
            {
                Animator.Play("Loop");
                isMoving = true;
            }
            else if (Animator.GetCurrentAnimatorStateInfo(0).IsName("Explotar"))
            {
                Destroy(gameObject);
            }
        }

        timer += Time.deltaTime;

        if (timer >= timeToDestroy)
        {
            Explode();
        }
    }

    public void Initialize(Vector3 direction)
    {
        this.direction = direction;
    }

    public void Move()
    {
        transform.position += speed * Time.deltaTime * new Vector3(direction.x, 0, direction.z);
    }

    public void Explode()
    {
        Animator.Play("Explotar");
        isMoving = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player");
            other.GetComponent<IDamageable>().TakeDamage(damage);
            Explode();
        }
    }
}
