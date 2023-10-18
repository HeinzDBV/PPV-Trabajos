using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1TriggerAreaBehavior : MonoBehaviour
{
    public bool playerHasEntered = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHasEntered = true;
        }
    }
}
