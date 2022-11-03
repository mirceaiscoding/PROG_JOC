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

    private Transform homingTarget;

    // Updates velocity
    Vector2 lastVelocity;

    // True if the bullet bounces off of walls
    bool isBouncy = false;

    // Number of times the bullet can bounce off
    int bouncesRemaining = 0;

    // True if the bullet follows enemies
    bool isHoming = false;

    // How fast can a homing bullet turn
    float homingSpeed = 300;

    // The minimum distance from an enemy, after which the bullet starts homing
    float homingDistance = 5;

    public void SetIsBouncy(bool flag)
    {
        isBouncy = flag;

        //number of times the bullet is supposed to bounce
        bouncesRemaining = 4;
    }

    public void SetIsHoming(bool flag)
    {
        isHoming = flag;
    }

    void Start(){
        //stop the rigidbody of the bullet from rotating
        rigidbody.freezeRotation = true;
    }

    void Update() {
        
    }

    void FixedUpdate(){
        lastVelocity = rigidbody.velocity;

        if(isHoming){

            //find the nearest enemy and rotate the bullet towards it
            homingTarget = GameObject.FindGameObjectWithTag("Enemy").transform;
            float distance = Vector3.Distance (rigidbody.position, homingTarget.position);
            if(distance <= homingDistance){

                //re-enable rigidbody rotation 
                rigidbody.freezeRotation = false;

                //start rotating the bullet
                Vector2 direction = (Vector2)homingTarget.position - rigidbody.position;
                direction.Normalize();
                float rotateAmount = Vector3.Cross(direction, transform.right).z;
                rigidbody.angularVelocity = -rotateAmount * homingSpeed;

                //bullet moves in the direction it is rotated
                var speed = lastVelocity.magnitude;
                rigidbody.velocity = transform.right*speed;
            }
            else{
                rigidbody.freezeRotation = true;
            }

        }
        
    }

    //Regular collider of the bullet(without trigger)
    private void OnCollisionEnter2D(Collision2D other) {

        switch (other.gameObject.tag) 
        {
            // Bullet hits a wall. Destroys itself if it isn't bouncy
            case "Wall":

                if (isBouncy && bouncesRemaining > 0)
                {
                    bouncesRemaining-=1;

                    //change the direction the bullet id facing when it hits a wall
                    var direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);
                    Quaternion newRotation = Quaternion.LookRotation(Vector3.forward, Quaternion.Euler(0, 0, 90) * direction);
                    transform.rotation = newRotation;

                    //bullet moves in the new direction
                    var speed = lastVelocity.magnitude;
                    rigidbody.velocity = transform.right*speed;

                } else {
                    destroyBullet();
                }
                break;
        }
    }

    //Collider with trigger
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
