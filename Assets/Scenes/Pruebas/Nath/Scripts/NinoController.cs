using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinoController : MonoBehaviour
{
    public float moveSpeed = 1.0f; // Velocidad de movimiento del NPC.
    public float moveDistance = 2.0f; // Distancia máxima que el NPC recorrerá en cada dirección.
    public Transform player;
    public float distancia;

    private bool isWalking = false; // Indica si el NPC está caminando.
    private Vector3 originalPosition; // Posición original del NPC.
    private Vector3[] moveDirections = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right }; // Direcciones de movimiento en el eje X y Z.
    private int currentDirectionIndex = 0; // Índice de la dirección actual.

    void Start()
    {
        originalPosition = transform.position;
        StartCoroutine(WalkInDirections());
    }

    void Update()
    {
        distancia = (transform.position - player.position).magnitude;
        if (Input.GetKeyDown(KeyCode.Space) && distancia<=3f)
        {
            // El jugador presionó la tecla Espacio, detiene al NPC.
            StopCoroutine(WalkInDirections());
            isWalking = false;
        }
    }

    IEnumerator WalkInDirections()
    {
        isWalking = true;
        while (isWalking)
        {
            // Calcula el destino actual en la dirección actual.
            Vector3 currentDestination = originalPosition + moveDirections[currentDirectionIndex] * moveDistance;

            // Mueve al NPC hacia el destino actual.
            transform.position = Vector3.MoveTowards(transform.position, currentDestination, moveSpeed * Time.deltaTime);

            // Si llega al destino, cambia a la siguiente dirección.
            if (Vector3.Distance(transform.position, currentDestination) < 0.01f)
            {
                currentDirectionIndex = (currentDirectionIndex + 1) % moveDirections.Length;
            }

            yield return null;
        }
    }
}
