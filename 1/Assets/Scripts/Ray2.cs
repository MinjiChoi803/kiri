using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray2 : MonoBehaviour
{
    public float range = 15f;
    //public int damage = 3;
    private LineRenderer trail;
    //public ParticleSystem hitEffect;

    void Start()
    {
        trail = GetComponent<LineRenderer>();
        // StartCoroutine(RedrawLaser());
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    public void Fire()
    {
        float rangeLeft = range;
        Vector3 rayPosition = transform.position;
        Vector3 rayDirection = transform.forward;
        //LineRenderer rayRenderer = (LineRenderer)Instantiate(trail, Vector3.zero, Quaternion.identity);
        trail.SetVertexCount(1);
        trail.SetPosition(0, transform.position);
        int vertexCount = 1;

        while (rangeLeft > 0f)
        {
            RaycastHit hit;
            Vector3 rayFinish = rayPosition + rayDirection * rangeLeft;
            //Debug.DrawLine(rayPosition, rayFinish, Color.green);
            if (Physics.Linecast(rayPosition, rayFinish, out hit))
            {
                //Debug.DrawLine(rayPosition, hit.point);
                Debug.Log("Ray hit:       " + hit.point);

                // Instantiating hit effect
                //Quaternion hitRotation = new Quaternion();
               // hitRotation.SetLookRotation(hit.normal);
                //Instantiate(hitEffect, hit.point, hitRotation);

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
    //protected override void Shoot()
    //{
    //    float rangeLeft = range;
    //    Vector3 rayPosition = transform.position;
    //    Vector3 rayDirection = transform.forward;
    //    LineRenderer rayRenderer = (LineRenderer)Instantiate(trail, Vector3.zero, Quaternion.identity);
    //    rayRenderer.SetVertexCount(1);
    //    rayRenderer.SetPosition(0, transform.position);
    //    int vertexCount = 1;
    //    while (rangeLeft > 0f)
    //    {
    //        /*
    //           This loop should actually never finish on this condition, and always finish on the break later.
    //           However, I added this just as a precaution against a neverending loop.
    //          */
    //        RaycastHit hit;
    //        Vector3 rayFinish = rayPosition + rayDirection * rangeLeft;
    //        Debug.DrawLine(rayPosition, rayFinish, Color.green);
    //        if (Physics.Linecast(rayPosition, rayFinish, out hit))
    //        {
    //            Debug.DrawLine(rayPosition, hit.point);
    //            Debug.Log("Ray hit:       " + hit.point);

    //            // Instantiating hit effect
    //            Quaternion hitRotation = new Quaternion();
    //            hitRotation.SetLookRotation(hit.normal);
    //            Instantiate(hitEffect, hit.point, hitRotation);
    //            // Reflecting
    //            rayPosition = rayPosition = hit.point;
    //            rayDirection = Vector3.Reflect(rayDirection, hit.normal);
    //            rangeLeft -= hit.distance;
    //            // Adding hit point to the rayRenderer
    //            rayRenderer.SetVertexCount(++vertexCount);


    //            rayRenderer.SetPosition(vertexCount - 1, rayPosition);

    //            // If we hit something, inflicting damage

    //            //Health targetHealth = hit.collider.GetComponent<Health>();

    //            //if (targetHealth)
    //            //{

    //            //    targetHealth.InflictDamage(damage);

    //            //}
    //        }
    //        else
    //        {
    //            // Adding final point to the line renderer

    //            rayRenderer.SetVertexCount(++vertexCount);


    //            rayRenderer.SetPosition(vertexCount - 1, rayFinish);
    //            break;
    //        }
    //    }
    //    Debug.Break();
    //}

}
