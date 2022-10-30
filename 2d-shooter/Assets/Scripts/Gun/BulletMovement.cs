using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    // RigidBody of bullet. Set in Unity Editor
    public Rigidbody2D rigidbody;

    // Effect played before a bullet is destroyed. Set in Unity Editor
    public GameObject destroyBulletAnimation;

    // Effect played when an enemy is hit. Set in Unity Editor
    public GameObject enemyHitAnimation;

    // Speed to knockback the enemy. Set in Unity Editor
    public float knockbackSpeed;

    // Time for which to knockback the enemy. Set in Unity Editor
    public float knockbackTime;

    // True if the bullet bounces off of walls
    bool isBouncy = false;

    //Number of times the bullet can bounce off
    int bouncesRemaining = 0;

    // Updates velocity
    Vector2 lastVelocity;

    public void SetIsBouncy(bool flag)
    {
        isBouncy = flag;
        bouncesRemaining = 5;
    }

    void Update() {
        lastVelocity = rigidbody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other) {

        switch (other.gameObject.tag) 
        {
            // Bullet hits a wall. destroy itself
            case "Wall":

                if (isBouncy && bouncesRemaining > 0)
                {
                    bouncesRemaining-=1;
                    // Bounce back
                    var speed = lastVelocity.magnitude;
                    var direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);
                    rigidbody.velocity = direction * Mathf.Max(0f, speed);
                    
                } else {
                    destroyBullet();
                }
                break;
        }
    }

    // Called when the bullet enters another 2d collider
    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag) 
        {
            

            // Bullet hits an enemy. Damage the enemy and destroy the bullet.
            case "Enemy":
                // TODO: Damage enemy

                // Knockback enemy
                Vector2 knockbackVelocity = (other.transform.position - transform.position).normalized * knockbackSpeed;

                var movement = other.gameObject.GetComponent<Movement>();
                movement.Knockback(knockbackVelocity, knockbackTime);

                // Destroy bullet with hit animation
                destroyBullet(true);
                break;

            // Add other checkers here...
        }
    }

    // Destroy the bullet and play an animation
    void destroyBullet(bool hitEnemy = false) 
    {
        if (hitEnemy) {
            Instantiate(enemyHitAnimation, transform.position, Quaternion.identity);
        } else {
            Instantiate(destroyBulletAnimation, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
