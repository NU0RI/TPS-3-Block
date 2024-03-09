using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSource : MonoBehaviour
{
    public Transform TargetPoint;
    public Camera cameraLink;
    public float targetInSkyDistance;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        var ray = cameraLink.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            TargetPoint.position = hit.point;
        }
        else
        {
            TargetPoint.position = ray.GetPoint(targetInSkyDistance);
        }

        transform.LookAt(TargetPoint.position);
    }
}
