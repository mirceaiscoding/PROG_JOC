using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDeath : MonoBehaviour
{
    public Health enemyHealth;

    private void OnEnable()
    {
        enemyHealth.OnDeath += Die;
    }

    private void OnDisable()
    {
        enemyHealth.OnDeath -= Die;
    }

    public void Die()
    {

        var enemyAI = GetComponent<EnemyAI>();
        Destroy(enemyAI);

        var rigidbody = GetComponent<Rigidbody2D>();
        Destroy(rigidbody);

        var collider = GetComponent<Collider2D>();
        Destroy(collider);

        // Play death animation
        var animator = GetComponent<Animator>();
        animator.SetBool("IsDead", true);

        // Destroy self in 2 seconds
        Destroy(gameObject, 2f);

    }
}
