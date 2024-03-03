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
    public float damage = 30;
    public bool IsPlayerNoticed;
  
    private NavMeshAgent _navMeshAgent;
    private PlayerHealth _playerHealth;

    void Start()
    {

        InitComponentLinks();
        PickNewPatrolPoint();
    }

    void Update()
    {
        ChaseUpdate();
        NoticePlayerUpdate();
        AttackUpdate();
        PatrolUpdate();
    }
    public void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoint[Random.Range(0, patrolPoint.Count)].position;
    }

    public void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
    }

    public void PatrolUpdate()
    {
        if (!IsPlayerNoticed)
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.remainingDistance)
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
    public void AttackUpdate()
    {
        if(IsPlayerNoticed) 
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _playerHealth.DealDamage(damage * Time.deltaTime);
            }
        }
    }
}