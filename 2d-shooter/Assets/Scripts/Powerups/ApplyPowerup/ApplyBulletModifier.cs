using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyBulletModifier : ApplyModifier
{
    //when th player touches the item, add the powerup to bullet modifiers(list in GunFire.cs)
    public override void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<PlayerShooting>().gun.bulletModifiers.Add(power);
            Destroy(gameObject);
        }
    }
}
