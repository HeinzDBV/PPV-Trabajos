using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 newPos = new Vector3(horizontal, vertical, 0.0f)* speed * Time.deltaTime;
        transform.Translate(newPos);
    }
}
