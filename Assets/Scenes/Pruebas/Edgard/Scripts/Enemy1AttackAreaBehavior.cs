using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1AttackAreaBehavior : MonoBehaviour
{
    public bool canAttack = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canAttack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canAttack = false;
        }
    }
}
