using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gives an EnemyBehaviour to an enemy
public class EnemyAI : MonoBehaviour
{
    // EnemyBehaviour set from Unity Editor
    public EnemyBehaviour enemyBehaviour;

    // On start init the enemyBehaviour
    void Start()
    {
        enemyBehaviour.Init(this);
    }

    // On fixed update call the enemyBehaviour think method
    void FixedUpdate()
    {
        enemyBehaviour.Think(this);
    }
}
