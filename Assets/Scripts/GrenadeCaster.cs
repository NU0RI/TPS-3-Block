using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public float damage = 50;
    public Rigidbody GrenadePrefab;
    public Transform GrenadeSourceTransform;

    private float force = 400;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var grenade = Instantiate(GrenadePrefab);
            grenade.transform.position = GrenadeSourceTransform.position;
            grenade.GetComponent<Rigidbody>().AddForce(GrenadeSourceTransform.forward * force);
            grenade.GetComponent<Grenade>().damage = damage;
        }
    }
}
