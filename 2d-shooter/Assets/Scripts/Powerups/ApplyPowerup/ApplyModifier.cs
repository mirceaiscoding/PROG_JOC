using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ApplyModifier : MonoBehaviour
{
    //powerup given by the item. Set in unity editor(using a scriptable object).
    public Powerup power;

    public abstract void OnTriggerEnter2D(Collider2D other);
}
