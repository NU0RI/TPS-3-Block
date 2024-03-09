using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackEvent : MonoBehaviour
{
    public EnemyAI EnemyAI;
    public void AttackDamage1()
    {
        EnemyAI.AttackDamage();
    }
    public void AttackDamage2()
    {
        EnemyAI.AttackDamage();
    }
}
