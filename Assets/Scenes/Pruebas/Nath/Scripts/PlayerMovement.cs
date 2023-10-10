using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 Speed = new Vector3(4f, 0f, 4f);
    [SerializeField]
    private float jumpForce = 5.0f;

    private Rigidbody rb;
    private Animator animator;
    private PlayerInput playerInput;
    private bool isGrounded;
    private Vector2 moveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        moveDir = playerInput.actions["Move"].ReadValue<Vector2>(); // Obtener la dirección del movimiento

        moveDir.Normalize();
        rb.velocity = new Vector3(
            moveDir.x * Speed.x,
            rb.velocity.y,
            moveDir.y * Speed.z
        );

        // Comprobar si el jugador está en el suelo
        isGrounded = CheckGrounded();

        if (isGrounded && playerInput.actions["Jump"].triggered)
        {
            Jump();
        }

        UpdateAnimation();
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void UpdateAnimation()
    {
        if (Mathf.Abs(moveDir.x) > Mathf.Epsilon || Mathf.Abs(moveDir.y) > Mathf.Epsilon)
        {
            animator.SetBool("IsWalking", true);
            animator.SetFloat("Horizontal", moveDir.x);
            animator.SetFloat("Vertical", moveDir.y);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    // Esta función verifica si el jugador está en el suelo usando un Raycast hacia abajo
    private bool CheckGrounded()
    {
        float raycastDistance = 1f; // Ajusta la distancia del Raycast según tus necesidades

        if (Physics.Raycast(transform.position, Vector3.down, raycastDistance, 1 << LayerMask.NameToLayer("Ground")))
        {
            return true;
        }

        return false;
    }
}


