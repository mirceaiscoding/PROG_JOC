using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EnemyBehaviour that move towards the player
[CreateAssetMenu(menuName = "EnemyBehaviour/ChasePlayer")]
public class ChasePlayer : EnemyBehaviour
{

    // Tag of the target. Set in the Unity Editor. Defaults to Player
    public string targetTag = "Player";

    public override void DoAction(EnemyAI enemyAI) 
    {
        // Find the player location
        GameObject target = GameObject.FindGameObjectWithTag(targetTag);
        if (target) {
            // Found a target

            var movement = enemyAI.gameObject.GetComponent<Movement>();
            if (movement) {
                // Move towards target
                movement.MoveTowards(target.transform.position);
            }
        }
    }
}
