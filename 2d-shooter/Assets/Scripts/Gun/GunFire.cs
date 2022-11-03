using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    // Used for getting the position of the main camera. Set in Unity Editor
    public Camera sceneCamera;

    // A bullet that can be fired from the gun. Set in Unity Editor
    public GameObject bullet;

    // The spawning point of the bullet. Set in Unity Editor
    public Transform firePoint; 

    // The current position of the mouse
    private Vector2 mousePosition;

    // The speed of the bullet. Set in Unity Editor. Defaults to 10
    public float fireForce = 10.0f;

    // The bullet modifiers.
    public List<Powerup> bulletModifiers = new List<Powerup>();

    //The number of bullets shot when the gun fires
    private int BulletsFired = 1;

    //Number of degrees between bullets shot at the same time
    private int BulletSpread = 10;

    //Increase the number of bullets fired
    public void AddShots(int nr)
    {
        BulletsFired += nr;
    }

    void Update()
    {
        updateMousePosition();
    }

    // Independent of framerate
    void FixedUpdate()
    {
        RotateGun();
    }

    // Get current mouse position in reference to the main camera
    void updateMousePosition() {
       mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    // Rotate the gun after the mouse
    void RotateGun() 
    {
        Vector2 aimDirection = mousePosition - (Vector2)transform.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (aimAngle-90));
    }

    //Spawns a bullet then makes it move to the right of the spawn point (where the mouse is pointed)
    public void Fire()
    {
        //Shoot multiple bullets at the same time in a cone
        for (int i = 0; i < BulletsFired; i++){

            //create a bullet
            GameObject projectile = Instantiate(bullet, firePoint.position, Quaternion.Euler(0, 0, BulletSpread*( ((float) BulletsFired-1) / 2 - i ))*firePoint.rotation) as GameObject;

            //add all the powerups to the bullet
            foreach (Powerup bulletModifier in bulletModifiers)
            {
                bulletModifier.Apply(projectile);
            }

            //fire the bullet
            projectile.GetComponent<Rigidbody2D>().velocity = (Quaternion.Euler(0, 0, BulletSpread*( ((float) BulletsFired-1) / 2 - i )) * firePoint.right) * fireForce;
        }
    }
}

