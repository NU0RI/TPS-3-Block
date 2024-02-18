using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * -Speed * Time.fixedDeltaTime;
    }
}
