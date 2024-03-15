using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public PlayerProgress playerProgress;

    public Animator animator;
    public bool IsAlive()
    {
        return value > 0;
    }
   public void DealDamage(float damage)
    {
       value -= damage;
        if (value <= 0)
        {
            EnemyDeath();
            playerProgress.AddExperience(10);
        }
    }

    private void EnemyDeath()
    {
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        animator.SetTrigger("death");
        Destroy(gameObject, 30);
    }

    private void Start()
    {
       playerProgress = FindObjectOfType<PlayerProgress>();
    }
}
