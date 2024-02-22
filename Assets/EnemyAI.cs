using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoint;
    public PlayerController player;

    private NavMeshAgent _navMeshAgent;

    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    void Update()
    {
        PatrolUpdate();
    }

    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoint[Random.Range(0, patrolPoint.Count)].position;
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance == 0)
        {
            PickNewPatrolPoint();
        }
    }
}
