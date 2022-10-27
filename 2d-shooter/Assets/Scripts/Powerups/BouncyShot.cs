using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Bullets/Bouncy")]
public class BouncyShot : Powerup
{
    public override void Apply(GameObject bullet)
    {
        bullet.GetComponent<BulletMovement>().SetIsBouncy(true);
    }
}
