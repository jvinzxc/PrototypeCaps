using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AnimalState
{
    Idle,
    Moving,
    Chase,
}

[RequireComponent(typeof(NavMeshAgent))]
public class Animal : MonoBehaviour
{
    [Header("Wander")]
    [SerializeField] private float wanderDistance = 50f;
    // how far can animal go
    [SerializeField] private float walkSpeed = 5f;
    // how fast animal can go
    [SerializeField] private float maxWalkTime = 6f;

    [Header("Idle")]
    [SerializeField] private float idleTime = 3f;
    // how long animal gonna stay still

    [Header("Chase")]
    [SerializeField] private float runSpeed = 8f;

    [Header("Attributes")]
    [SerializeField] public int health = 100;

    protected NavMeshAgent navMeshAgent;
    protected Animator animator;
    protected AnimalState currentState = AnimalState.Idle;

    private void Start()
    {
        InitialiseAnimal();
    }
    protected virtual void InitialiseAnimal()
    {
        animator = transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = walkSpeed;

        currentState = AnimalState.Idle;
        UpdateState();
    }
    
    protected virtual void UpdateState()
    {
        switch (currentState)
        {
            case AnimalState.Idle:
                HandleIdleState();
                break;
            case AnimalState.Moving:
                HandleMovingState();
                break;
            case AnimalState.Chase:
                HandleChaseState();
                break;
        }
    }
    protected Vector3 GetRandomNavMeshPosition(Vector3 origin, float distance)
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 randomDirection = Random.insideUnitSphere * distance;
            randomDirection += origin;
            NavMeshHit navMeshHit;

            if (NavMesh.SamplePosition(randomDirection, out navMeshHit, distance, NavMesh.AllAreas))
            {
                return navMeshHit.position;
            }
            
        }
        return origin;
    }
    protected virtual void CheckChaseConditions()
    {

    }
    protected virtual void HandleChaseState()
    {
        StopAllCoroutines();
    }
    protected virtual void HandleIdleState()
    {
        StartCoroutine(WaitToMove());
    }
    protected virtual void HadleStopState()
    {
        StartCoroutine(StopMoving());
    }
    public IEnumerator StopMoving()
    {
        wanderDistance = 0;
        walkSpeed = 0;
        maxWalkTime = 0;
        navMeshAgent.stoppingDistance = wanderDistance;
        yield return new WaitForSeconds(idleTime);

    }
    public IEnumerator WaitToMove()
    {
        wanderDistance = 50f;
        walkSpeed = 5f;
        maxWalkTime = 6f;
        float waitTime = Random.Range(idleTime / 2, idleTime * 2);
        yield return new WaitForSeconds(waitTime);

        Vector3 randomDistanation = GetRandomNavMeshPosition(transform.position, wanderDistance);
        navMeshAgent.SetDestination(randomDistanation);
        SetState(AnimalState.Moving);
    }
    protected virtual void HandleMovingState()
    {
        StartCoroutine(WaitToReachDistination());
    }
    private IEnumerator WaitToReachDistination()
    {
        float startTime = Time.time;

        while (navMeshAgent.pathPending || navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance && navMeshAgent.isActiveAndEnabled)
        {
            if (Time.time - startTime >= maxWalkTime)
            {
                navMeshAgent.ResetPath();
                SetState(AnimalState.Idle);
                yield break;
            }
            CheckChaseConditions();
            yield return null;
        }
        //Distination has been reach
        SetState(AnimalState.Idle);
    }
    protected void SetState(AnimalState newState)
    {
        if(currentState == newState) 
            return;
        currentState = newState;
        OnStateChanged(newState);
    }
    protected virtual void OnStateChanged(AnimalState newState)
    {
        animator?.CrossFadeInFixedTime(newState.ToString(), 0.5f);
        if(newState == AnimalState.Moving)
        {
            navMeshAgent.speed = walkSpeed;
        }
        if(newState == AnimalState.Chase) 
        {
            navMeshAgent.speed = runSpeed;
        }
        UpdateState();
    }
    public void recieveDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }
    protected virtual void Die()
    {
        // health is zero stop animal program and destroy model
        StopAllCoroutines();
        //Destroy(gameObject);
        animator.SetTrigger("sleep");
    }
}
