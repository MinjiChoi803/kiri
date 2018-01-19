using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{
    public float range = 15f;
    private LineRenderer trail;

    void Start()
    {
        trail = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Fire();
    }

    public void Fire()
    {
        float rangeLeft = range;
        Vector3 rayPosition = transform.position;
        Vector3 rayDirection = transform.forward;
        trail.SetVertexCount(1);
        trail.SetPosition(0, transform.position);
        int vertexCount = 1;

        while (rangeLeft > 0f)
        {
            RaycastHit hit;
            Vector3 rayFinish = rayPosition + rayDirection * rangeLeft;
            if (Physics.Linecast(rayPosition, rayFinish, out hit) && ((hit.transform.gameObject.tag == "bounceTag")))
            {
                Debug.Log("Ray hit:       " + hit.point);

                // Reflecting
                rayPosition = rayPosition = hit.point;
                rayDirection = Vector3.Reflect(rayDirection, hit.normal);
                rangeLeft -= hit.distance;
                // Adding hit point to the rayRenderer
                trail.SetVertexCount(++vertexCount);


                trail.SetPosition(vertexCount - 1, rayPosition);
            }
            else
            {
                // Adding final point to the line renderer
                trail.SetVertexCount(++vertexCount);
                trail.SetPosition(vertexCount - 1, rayFinish);
                break;
            }
        }
    }
}