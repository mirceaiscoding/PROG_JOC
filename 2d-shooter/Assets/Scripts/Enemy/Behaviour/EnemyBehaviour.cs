using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Abstart class for enemy behaviours
public abstract class EnemyBehaviour : ScriptableObject
{
    // Called when the behaviour is instantiated
    public abstract void Init(EnemyAI enemyAI);

    // Called on update
    public abstract void Think(EnemyAI enemyAI);
}
