
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyBaseState : MonoBehaviour 
{
    public abstract void EnterState(EnemyBehaviourManager enemyBaseState);

    public abstract void UpdateState(EnemyBehaviourManager enemyBaseState);

    public abstract void OnCollisionEnter(EnemyBehaviourManager enemyBaseState);

    
}
