using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoint;
    public PlayerController player;
    public float viewAngle;
    public bool IsPlayerNoticed;

    private NavMeshAgent _navMeshAgent;
    

    void Start()
    {
        
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    void Update()
    {
        ChaseUpdate();
        NoticePlayerUpdate();
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
            if (IsPlayerNoticed == true)
                {
                    PickNewPatrolPoint();
                }
    }

    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        if (Vector3.Angle(transform.position, direction) < viewAngle)
        {
            IsPlayerNoticed = false;
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    IsPlayerNoticed = true;
                }
            }
        }
    }
    private void ChaseUpdate()
    {
        if (IsPlayerNoticed == true)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
}