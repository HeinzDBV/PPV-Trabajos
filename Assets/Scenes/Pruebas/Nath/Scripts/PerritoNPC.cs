using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerritoNPC : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float moveDistance = 5.0f;
    public Animator animator;
    public string runParameter = "IsRunning";

    private Vector3 initialPosition;
    private bool isMoving = true;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (isMoving)
        {

            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);


            if (Vector3.Distance(initialPosition, transform.position) >= moveDistance)
            {
                transform.Rotate(Vector3.up, 180);
                initialPosition = transform.position;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            isMoving = false;

            if (animator != null)
            {
                animator.SetBool(runParameter, false);
            }
        }
        else
        {

            if (animator != null)
            {
                animator.SetBool(runParameter, true);
            }
        }
    }
}
