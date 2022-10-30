using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyGunModifier : ApplyModifier
{
    //when th player touches the item, add the powerup to gun modifiers(list in GunFire.cs)
    public override void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<PlayerShooting>().gun.gunModifiers.Add(power);
            Destroy(gameObject);
        }
    }
}
