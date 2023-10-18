using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBehavior : MonoBehaviour
{
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public int order;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement.OnPlayerHealthChange += UpdateHealth;
        CurrentHealth = MaxHealth;
        animator = GetComponent<Animator>();
    }

    public void UpdateHealth(float health)
    {
        CurrentHealth = health;
        ChangeAnimation();
    }

    public void ChangeAnimation()
    {
        float fill = CurrentHealth - 4 * order;
        if (fill >= 0)
        {
            fill = 4;
        }
        else if (fill == -1)
        {
            fill = 3;
        }
        else if (fill == -2)
        {
            fill = 2;
        }
        else if (fill == -3)
        {
            fill = 1;
        }
        else
        {
            fill = 0;
        }

        animator.Play("Heart_" + fill);
    }
}
