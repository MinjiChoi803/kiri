
using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{

    private LineRenderer lr;

    //public int laserDistance;
    //public string bounceTag;
    //public int maxBounce;

    // Use this for initialization
    void Start()
    {
        lr = GetComponent<LineRenderer>();
       // StartCoroutine(RedrawLaser());
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(RedrawLaser());
    }

    IEnumerator RedrawLaser()
    {
        bool loopActive = true;
        Vector3 laserDirection = transform.forward; //다음 레이저 방향(direction)
        Vector3 lastLaserPosition = transform.localPosition; //다음 레이져 시작위치(origin)
        //LineRenderer rayRenderer = (LineRenderer)Instantiate(lr, Vector3.zero, Quaternion.identity);
        //int laserReflected = 1;
        int vertexCounter = 1;
        lr.SetVertexCount(1);
        lr.SetPosition(0, transform.position);

        RaycastHit hit;
        //Vector3 rayFinish = lastLaserPosition + laserDirection;

        while (loopActive)
        {
            if (Physics.Raycast(lastLaserPosition, laserDirection, out hit))
            {
                if (hit.collider)
                {
                    Debug.Log("Hit");
                    Debug.Log("Physics.Raycast(" + lastLaserPosition + ", " + laserDirection); //(0,0,0) (0,0,1)
                                                                                               //laserReflected++;
                                                                                               //vertexCounter += 1;
                                                                                               //lr.SetVertexCount(vertexCounter);
                                                                                               //lr.SetPosition(vertexCounter - 3, Vector3.MoveTowards(hit.point, lastLaserPosition, 0.01f));
                                                                                               //lr.SetPosition(vertexCounter - 2, hit.point);
                                                                                               //lr.SetPosition(vertexCounter - 1, hit.point);                                                                          

                    //반사
                    lastLaserPosition = hit.point;
                    Debug.Log("hit.point : " + hit.point);
                    //Vector3 prevDirection = laserDirection; //이전 방향 저장
                    laserDirection = Vector3.Reflect(laserDirection, hit.normal); //반사각(방향) 저장
                    lr.SetVertexCount(++vertexCounter);
                    //lr.SetPosition(vertexCounter-1, hit.point);
                    lr.SetPosition(vertexCounter - 1, lastLaserPosition);
                }
            }
            else lr.SetPosition(1, transform.forward * 5000);

        }
        yield return new WaitForEndOfFrame();
    }

    //IEnumerator RedrawLaser()
    //{
    //    //int laserSplit = 1; //How many times it got split
    //    int laserReflected = 1; //How many times it got reflected
    //    int vertexCounter = 1; //선 갯수
    //    bool loopActive = true; //Is the reflecting loop active?
    //    Vector3 laserDirection = transform.forward; //다음 레이저 방향(direction)
    //    Vector3 lastLaserPosition = transform.localPosition; //다음 레이져 시작위치(origin)
    //    lr.SetVertexCount(1); //선 갯수
    //    lr.SetPosition(0, transform.position); //초기 
    //    RaycastHit hit;

    //    while (loopActive)
    //    {
    //        if (Physics.Raycast(lastLaserPosition, laserDirection, out hit, laserDistance) && ((hit.transform.gameObject.tag == bounceTag)))
    //        {
    //            laserReflected++;
    //            vertexCounter += 3;
    //            lr.SetVertexCount(vertexCounter);
    //            lr.SetPosition(vertexCounter - 3, Vector3.MoveTowards(hit.point, lastLaserPosition, 0.01f));
    //            lr.SetPosition(vertexCounter - 2, hit.point);
    //            lr.SetPosition(vertexCounter - 1, hit.point);
    //            lr.SetWidth(.01f, .01f);
    //            lastLaserPosition = hit.point;
    //            Vector3 prevDirection = laserDirection;
    //            laserDirection = Vector3.Reflect(laserDirection, hit.normal);
    //        }
    //        else
    //        {
    //            //Debug.Log("No Bounce");
    //            laserReflected++;
    //            vertexCounter++;
    //            lr.SetVertexCount(vertexCounter);
    //            Vector3 lastPos = lastLaserPosition + (laserDirection.normalized * laserDistance);
    //            //Debug.Log("InitialPos " + lastLaserPosition + " Last Pos" + lastPos);
    //            lr.SetPosition(vertexCounter - 1, lastLaserPosition + (laserDirection.normalized * laserDistance));
    //            loopActive = false;
    //        }
    //        if (laserReflected > maxBounce)
    //            loopActive = false;
    //    }

    //    yield return new WaitForEndOfFrame();
    //}
}
