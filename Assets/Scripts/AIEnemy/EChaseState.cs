
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EChaseState : EnemyBaseState 
{

    

    public override void EnterState(EnemyBehaviourManager enemyBaseState) 
    {
        enemyBaseState.animator.SetBool("RunEqp", true);

    }

    public override void UpdateState(EnemyBehaviourManager enemyBaseState) 
    {


        enemyBaseState.MoveTowardsPlayer();
       
        if (enemyBaseState.CloseToPlayer())
        {
            enemyBaseState.SwitchState(enemyBaseState.attackState);
        }



    }

    public override void OnCollisionEnter(EnemyBehaviourManager enemyBaseState)
    { 


    }





}
