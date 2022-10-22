using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    // A bullet that can be fired from the gun. Set in Unity Editor
    public GameObject bullet;

    // The spawning point of the bullet. Set in Unity Editor
    public Transform firePoint; 

    // The speed of the bullet. Set in Unity Editor. Defaults to 10
    public float fireForce = 10.0f;

    //Spawns a bullet then makes it move to the right of the spawn point (where the mouse is pointed)
    public void Fire()
    {
        GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
    }
}

