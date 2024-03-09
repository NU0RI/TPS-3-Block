using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCaster : MonoBehaviour
{
    public Bullet BulletPrefab;
    public Transform BulletSourceTransform;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(BulletPrefab, BulletSourceTransform.position, BulletSourceTransform.rotation);
        }
    }
}
