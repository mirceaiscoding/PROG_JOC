using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gives an EnemyBehaviour to an enemy
public class EnemyAI : MonoBehaviour
{
    // EnemyBehaviour set from Unity Editor
    public EnemyBehaviour enemyBehaviour;

    // On fixed update call the enemyBehaviour
    void FixedUpdate()
    {
        enemyBehaviour.DoAction(this);
    }
}
