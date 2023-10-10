using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinoController : MonoBehaviour
{
    public float moveSpeed = 1.0f; // Velocidad de movimiento del NPC.
    public float moveDistance = 2.0f; // Distancia m�xima que el NPC recorrer� en cada direcci�n.

    private bool isWalking = false; // Indica si el NPC est� caminando.
    private Vector3 originalPosition; // Posici�n original del NPC.
    private Vector3[] moveDirections = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right }; // Direcciones de movimiento en el eje X y Z.
    private int currentDirectionIndex = 0; // �ndice de la direcci�n actual.

    void Start()
    {
        originalPosition = transform.position;
        StartCoroutine(WalkInDirections());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isWalking)
        {
            // El jugador presion� la tecla Espacio, detiene al NPC.
            StopCoroutine(WalkInDirections());
            isWalking = false;
        }
    }

    IEnumerator WalkInDirections()
    {
        isWalking = true;
        while (isWalking)
        {
            // Calcula el destino actual en la direcci�n actual.
            Vector3 currentDestination = originalPosition + moveDirections[currentDirectionIndex] * moveDistance;

            // Mueve al NPC hacia el destino actual.
            transform.position = Vector3.MoveTowards(transform.position, currentDestination, moveSpeed * Time.deltaTime);

            // Si llega al destino, cambia a la siguiente direcci�n.
            if (Vector3.Distance(transform.position, currentDestination) < 0.01f)
            {
                currentDirectionIndex = (currentDirectionIndex + 1) % moveDirections.Length;
            }

            yield return null;
        }
    }
}
