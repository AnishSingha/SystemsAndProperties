using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EIdleState : EnemyBaseState
{
    
    public override void EnterState(EnemyBehaviourManager enemyBaseState)
    {
        enemyBaseState.agent.isStopped = true;
        enemyBaseState.animator.SetBool("Idle", true);
        enemyBaseState.StartCoroutine(enemyBaseState.TurnDelay());


    }


    public override void UpdateState(EnemyBehaviourManager enemyBaseState)
    {
        enemyBaseState.TurnTowardsPlayer();

        if (enemyBaseState.isTurning == false && !enemyBaseState.CloseToPlayer())
        {
            enemyBaseState.agent.isStopped = false;

            enemyBaseState.SwitchState(enemyBaseState.chaseState);
        }

        else if (enemyBaseState.isTurning == false && enemyBaseState.CloseToPlayer())
        {
            enemyBaseState.agent.isStopped = false;

            enemyBaseState.SwitchState(enemyBaseState.attackState);
        }

    }


    public override void OnCollisionEnter(EnemyBehaviourManager enemyBaseState)
    {

    }
}
