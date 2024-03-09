using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float viewAngle;
    public List<Transform> patrolPonts;
    public PlayerController player;
    public float damage = 20;
    public float attackDistanse = 1;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private PlayerHealth _playerHealth;

    public Animator animator;

    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    private void Update()
    {

        NoticePlayerUpdate();
        ChaseUpdate();
        PatrolUpdate();
        AttackUpdate();
    }

    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPonts[Random.Range(0, patrolPonts.Count)].position;
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
    }

    private void NoticePlayerUpdate()
    {
        _isPlayerNoticed = false;
        if (!_playerHealth.IsAlive()) return;
        var direction = player.transform.position - transform.position;

        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }

    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                animator.SetTrigger("Attack");
            }
        }
    }

    public void AttackDamage()
    {
        if (!_isPlayerNoticed) return;
        if (_navMeshAgent.remainingDistance > (_navMeshAgent.stoppingDistance + attackDistanse)) return;

        _playerHealth.DealDamage(damage);
    }
}


