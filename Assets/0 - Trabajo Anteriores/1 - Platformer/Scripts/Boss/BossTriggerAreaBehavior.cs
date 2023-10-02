using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerAreaBehavior : MonoBehaviour
{
    public BossController boss;
    private void OnTriggerEnter2D(Collider2D other)
    {
        boss.OnTriggerEnter2DFunc(other);
    }
}

