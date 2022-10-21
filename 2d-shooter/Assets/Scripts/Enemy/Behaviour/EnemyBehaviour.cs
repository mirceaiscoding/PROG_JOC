using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Abstart class for enemy behaviours
public abstract class EnemyBehaviour : ScriptableObject
{
    public abstract void DoAction(EnemyAI enemyAI);
}
