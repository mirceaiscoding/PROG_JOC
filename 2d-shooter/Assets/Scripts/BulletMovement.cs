using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    // RigidBody of bullet. Set in Unity Editor
    public Rigidbody2D rigidbody;

    // Effect played before a bullet is destroyed. Set in Unity Editor
    public GameObject destroyBulletAnimation;

    // Called when the bullet enters another 2d collider
    void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag) 
        {
            // Bullet hits a wall. destroy itself
            case "Wall":
            destroyBullet();
            break;

            // You can add other checkers here
        }
    }

    // Destroy the bullet and play an animation
    void destroyBullet() 
    {
            Instantiate(destroyBulletAnimation, transform.position, Quaternion.identity);
            Destroy(gameObject);
    }

}
