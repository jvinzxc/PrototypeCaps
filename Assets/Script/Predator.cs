using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator : Animal
{
    [Header("Predator Variables")]
    [SerializeField] private float detectionRange = 20f;
    [SerializeField] private float maxChaseTime = 10f;
    [SerializeField] private int biteDamage = 5;
    [SerializeField] private float biteCooldown = 1f;

    private Pray currentChaseTarget;

    protected override void CheckChaseConditions()
    {
        if (currentChaseTarget) 
            return;

        Collider[] colliders = new Collider[10];
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, detectionRange, colliders);
        
        for (int i = 0; i < numColliders; i++)
        {
            Pray prey = colliders[i].GetComponent<Pray>();

            if (prey != null)
            {
                StartChase(prey);
                return;
            }
        }
        currentChaseTarget = null;    
    }
    private void StartChase(Pray prey)
    {
        currentChaseTarget = prey;
        SetState(AnimalState.Chase);
    }
    protected override void HandleChaseState()
    {
        if(currentChaseTarget != null)
        {
            currentChaseTarget.AlertPrey(this);
            StartCoroutine(ChasePrey());
        }
        else
        {
            SetState(AnimalState.Idle);
        }

    }
    private IEnumerator ChasePrey()
    {
        float startTime = Time.time;

        while (currentChaseTarget != null && Vector3.Distance(transform.position, currentChaseTarget.transform.position) > navMeshAgent.stoppingDistance)
        {
            if (Time.time - startTime >= maxChaseTime || currentChaseTarget == null)
            {
                StopChase();
                yield break;
            }
            SetState(AnimalState.Chase);
            navMeshAgent.SetDestination(currentChaseTarget.transform.position);

            yield return null;
        }
        if(currentChaseTarget)
            currentChaseTarget.recieveDamage(biteDamage);
        yield return new WaitForSeconds(biteCooldown);

        currentChaseTarget = null;
        HandleChaseState();

        CheckChaseConditions();
    }
    private void StopChase()
    {
        navMeshAgent.ResetPath();
        currentChaseTarget = null;
        SetState(AnimalState.Moving);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
