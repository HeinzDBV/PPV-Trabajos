using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrikingCheck : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; }
    private EnemyController _enemyController;

    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        _enemyController = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == PlayerTarget)
        {
            _enemyController.SetInAttackRange(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == PlayerTarget)
        {
            _enemyController.SetInAttackRange(false);
        }
    }
}
