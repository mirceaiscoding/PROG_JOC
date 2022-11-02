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
        if (enemyAI) Destroy(enemyAI);

        var rigidbody = GetComponent<Rigidbody2D>();
        if (rigidbody) Destroy(rigidbody);

        var collider = GetComponent<Collider2D>();
        if (collider) Destroy(collider);

        // Play death animation
        var animator = GetComponent<Animator>();
        if (animator)
        {
            animator.SetBool("IsDead", true);
        }

        // Destroy self in 2 seconds
        Destroy(gameObject, 2f);

    }
}
