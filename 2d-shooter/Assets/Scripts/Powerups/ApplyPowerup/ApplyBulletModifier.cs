using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyBulletModifier : MonoBehaviour
{
    //Set in unity editor(using a powerup scriptable object).
    public Powerup power;

    //when th player touches the item, add the powerup to bullet modifiers(list in GunFire.cs)
    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            ItemDescriptionManager.instance.PrintBulletDescription(gameObject.tag);
            GunDescriptionManager.instance.PrintBulletDescription(gameObject.tag);
            other.gameObject.GetComponent<PlayerShooting>().gun.bulletModifiers.Add(power);
            Destroy(gameObject);
        }
    }
}
