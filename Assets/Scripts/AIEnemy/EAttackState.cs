
using UnityEngine;

public class EAttackState : EnemyBaseState
{

    public override void EnterState(EnemyBehaviourManager enemyBaseState) 
    {
        enemyBaseState.agent.isStopped = true;
        string comboList = enemyBaseState.ComboList[Random.Range(0, enemyBaseState.ComboList.Length)];
        enemyBaseState.animator.SetBool(comboList, true);

        int index = System.Array.IndexOf(enemyBaseState.ComboList, comboList);

        float delay = (index != -1 && index < enemyBaseState.timeToWaitAfterEachAttack.Length)
           ? enemyBaseState.timeToWaitAfterEachAttack[index]
           : enemyBaseState.defaultDelayTime;


        enemyBaseState.StartCoroutine(enemyBaseState.WaitForAnimEnd(delay));

    }

    public override void UpdateState(EnemyBehaviourManager enemyBaseState)
    {
        if (!enemyBaseState.CloseToPlayer() && !enemyBaseState.isAttacking)
        {
            enemyBaseState.agent.isStopped = false;
            
            enemyBaseState.SwitchState(enemyBaseState.idleState);

        }
    }

    

    public override void OnCollisionEnter(EnemyBehaviourManager enemyBaseState)
    {
        
    }
}
