using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBehaviourManager : MonoBehaviour
{
    EnemyBaseState currentState;

    
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public EChaseState chaseState;
    [HideInInspector] public EAttackState attackState;
    [HideInInspector] public EDeathState deathState;
    [HideInInspector] public EIdleState idleState;

    [SerializeField]public Transform player; 
    public Animator animator;
    [SerializeField]public float stoppingDistance;
    [SerializeField]float rotationSPeed = 10f;

    [Space]
    [SerializeField] public Collider SwordCollider;

    [HideInInspector] public bool isAttacking;
    [HideInInspector] public bool isTurning;
    [Space(20)]
    [SerializeField] public float[] timeToWaitAfterEachAttack;
    [SerializeField] public float defaultDelayTime;

    [Space(20)]
    [SerializeField] public string[] ComboList;
    [SerializeField] public Dictionary<string, float> animationDelays = new Dictionary<string, float> { };    

    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        chaseState = new EChaseState();
        attackState = new EAttackState();
        deathState = new EDeathState();
        idleState = new EIdleState();
        currentState = idleState;

        currentState.EnterState(this);
    }


    private void Update()
    {
        currentState.UpdateState(this);
    }


    public void SwitchState(EnemyBaseState enemyBaseState) 
    {
        currentState = enemyBaseState;
        enemyBaseState.EnterState(this);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Handle collisions
        currentState.OnCollisionEnter(this);
    }

    public void MoveTowardsPlayer()
    {
        agent.SetDestination(player.position);
        
    }

    public bool CloseToPlayer()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= stoppingDistance)
        {
            return true;
        }
        return false;
    }

    public void TurnTowardsPlayer()
    {

        Vector3 direction = player.position - transform.position;

        // Ensure the object only rotates around the Y axis to face the player
        direction.y = 0f;

        if (direction != Vector3.zero)
        {
            // Rotate the object towards the player over time
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSPeed);
        }
    }

    public IEnumerator WaitForAnimEnd(float delay)
    {
        isAttacking = true;
        yield return new WaitForSeconds(delay);
        isAttacking = false;

    }

    public IEnumerator TurnDelay()
    {
        isTurning = true;

        yield return new WaitForSeconds(1.5f);
        isTurning = false;

    }

}


