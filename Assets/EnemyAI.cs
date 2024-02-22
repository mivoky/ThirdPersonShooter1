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
    public void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoint[Random.Range(0, patrolPoint.Count)].position;
    }

    public void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance == 0)
            if (IsPlayerNoticed == false)
                {
                    PickNewPatrolPoint();
                }
    }

    public void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        IsPlayerNoticed = false;
        if (Vector3.Angle(transform.position, direction) < viewAngle)
        {
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
    public void ChaseUpdate()
    {
        if (IsPlayerNoticed == true)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
}