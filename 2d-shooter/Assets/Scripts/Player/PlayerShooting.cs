using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Used for getting the position of the main camera. Set in Unity Editor
    public Camera sceneCamera;

    // RigidBody of player. Set in Unity Editor
    public Rigidbody2D rigidbody;

    // An instance of the GunFire class for calling it's methods
    public GunFire gun;

    // The current position of the mouse
    private Vector2 mousePosition;

    // Cooldown time between shots. Set in Unity Editor
    public float shotCooldown = 0.5F;

    // Time after which the player can shoot. 
    private float nextShotTime;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize nextShotTime to the current time.
        nextShotTime = Time.time;
    }

    // If the player can shoot the current time must be greater than nextShotTime
    private bool canShoot() 
    {
        return Time.time > nextShotTime;
    }

    // Update is called once per frame
    void Update()
    {
        updateMousePosition();
        Shoot();
    }

    // Independent of framerate
    void FixedUpdate()
    {
        RotatePlayer();
    }

    // Get current mouse position in reference to the main camera
    void updateMousePosition() {
       mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    // Rotate the player after the mouse
    void RotatePlayer() 
    {
        Vector2 aimDirection = mousePosition - rigidbody.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        rigidbody.rotation = aimAngle;
    }

    // When left-clicking uses the Fire method of the gun
    void Shoot()
    {
        if (Input.GetMouseButton(0))
            if (canShoot())
            {
                // Add cooldown to nextShotTime
                nextShotTime = Time.time + shotCooldown;
                
                // Fire gun
                gun.Fire();
            }
    }
}
