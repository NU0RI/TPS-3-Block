using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCaster : MonoBehaviour
{
    public float damage = 10;

    public Bullet BulletPrefab;
    public Transform BulletSourceTransform;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var Bullet = Instantiate(BulletPrefab, BulletSourceTransform.position, BulletSourceTransform.rotation);
            Bullet.damage = damage;
        }
    }
}
