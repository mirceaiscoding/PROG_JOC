using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// EnemyBehaviour that move towards the player following a path
[CreateAssetMenu(menuName = "EnemyBehaviour/PatrolAndChase")]
public class PatrolAndChase : EnemyBehaviour
{

    // Patrol enemy behaviour
    public Patrol patrol;

    // Chase enemy behaviour
    public SmartChase chase;

    // True if enemy is in chase mode
    bool isInChaseMode = false;

    public override void Init(EnemyAI enemyAI)
    {
        patrol.Init(enemyAI);
    }

    public override float GetRepetableBehaviourCooldown() 
    {
        return patrol.GetRepetableBehaviourCooldown();
    }

    public override void RepetableBehaviour(EnemyAI enemyAI)
    {
        patrol.RepetableBehaviour(enemyAI);
    }

    public override void Think(EnemyAI enemyAI) 
    {

        patrol.Think(enemyAI);

        // If enemy sees its target start chase mode
        if (!isInChaseMode)
        {
            var target = GameObject.FindGameObjectWithTag(chase.targetTag);
            var enemyTargetLinecast = Physics2D.Linecast(enemyAI.transform.position, target.transform.position, 1 << LayerMask.NameToLayer("Walls"));

            if (!enemyTargetLinecast.collider)
            {
                Debug.Log("Found target. Entered chase phase!");

                // No collision between enemy and target. Start chase phase
                isInChaseMode = true;
                enemyAI.SetCurrentEnemyBehaviur(chase);   

                // Update animation
                var animator = enemyAI.gameObject.GetComponent<Animator>();
                animator.SetBool("IsInChaseMode", true);
             
            }
        }
        
    }

}
