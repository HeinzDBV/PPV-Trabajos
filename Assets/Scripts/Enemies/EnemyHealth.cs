using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider = GetComponentInChildren<Slider>();
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void ChangeDirection(int direction)
    {
        transform.localScale = new Vector2(direction, 1f);
    }

}
