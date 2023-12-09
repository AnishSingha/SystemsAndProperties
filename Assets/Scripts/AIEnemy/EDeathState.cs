
using UnityEngine;

public class EDeathState : EnemyBaseState
{
    public override void EnterState(EnemyBehaviourManager enemyBaseState) 
    {
        enemyBaseState.animator.SetBool("DeathEqp", true);


    }

    public override void UpdateState(EnemyBehaviourManager enemyBaseState) { }

    public override void OnCollisionEnter(EnemyBehaviourManager enemyBaseState) { }
}
