using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public event Action OnDamaged;
    public event Action OnDeath;

    public float health, maxHealth;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        OnDamaged?.Invoke();

        if (health <= 0)
        {
            health = 0;
            Debug.Log("You're dead");
            OnDeath?.Invoke();
        }
    }
}
