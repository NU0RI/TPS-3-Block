using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public float lifetime;
    public float damage = 10;

    private void Start()
    {
        Invoke("DestroyBullet", lifetime);
    }

    void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        DestroyBullet();
    }
    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
   
    private void  DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
    }
}
