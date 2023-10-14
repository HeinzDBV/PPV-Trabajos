using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinoController : MonoBehaviour
{
    public float moveSpeed = 1.0f; // Velocidad de movimiento del NPC.
    public Transform[] waypoints; // Los 4 puntos que el NPC visitará en orden.
    public Transform player;
    public float distancia;

    private int currentWaypointIndex = 0; // Índice del punto actual.
    private Animator animator; // Referencia al Animator del NPC.

    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener la referencia al Animator del NPC.
        transform.position = waypoints[0].position; // Coloca al NPC en el primer punto.

        StartCoroutine(WalkToWaypoints());
    }

    void Update()
    {
        distancia = (transform.position - player.position).magnitude;

        if (Input.GetKeyDown(KeyCode.E) && distancia <= 3f)
        {
            // El jugador presionó la tecla E, detiene al NPC.
            StopCoroutine(WalkToWaypoints());

            // Configura el parámetro "IsWalking" en el Animator como falso.
            if (animator != null)
            {
                animator.SetBool("IsWalking", false);
            }
        }
    }

    IEnumerator WalkToWaypoints()
    {
        // Configura el parámetro "IsWalking" en el Animator como verdadero.
        if (animator != null)
        {
            animator.SetBool("IsWalking", true);
        }

        while (true)
        {
            // Obtiene el siguiente punto de destino.
            Transform currentWaypoint = waypoints[currentWaypointIndex];

            // Mueve al NPC hacia el destino actual.
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);

            // Si llega al destino, avanza al siguiente punto.
            if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.01f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }

            yield return null;
        }
    }
}
