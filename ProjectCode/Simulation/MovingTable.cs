using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTable : MonoBehaviour
{
    private Transform a;
    private Vector3 b;
    private float w1;
    private float w2;
    private float w3;
    private float r;
    // Start is called before the first frame update
    void Start()
    {
     a=GetComponent<Transform>();
        w1 = a.position.x;
        w2=a.position.y;
        w3 = a.position.z;
        r = (float) Math.Sqrt(Math.Pow(w1,2)+Math.Pow(w3,2));
    }

    // Update is called once per frame
    void Update()
    {
        if (MovingCam.CameraMoving.hasChanged)
        {
         

            float xxx= MovingCam.CameraMoving.eulerAngles.x;
            float yyy = MovingCam.CameraMoving.eulerAngles.y;
            float zzz = MovingCam.CameraMoving.eulerAngles.z;

            
            float x = (float)(MovingCam.CameraMoving.position.x+w1);
            float y = (MovingCam.CameraMoving.position.y+w2);
            float z = (float)(MovingCam.CameraMoving.position.z+w3);




            a.position =new Vector3(x, y, z);
           // a.eulerAngles=new Vector3(xxx, yyy, zzz);


            a.rotation = new Quaternion(MovingCam.CameraMoving.rotation.x, MovingCam.CameraMoving.rotation.y, MovingCam.CameraMoving.rotation.z,1);
            //Debug.Log(Quaternion.Euler(xx, yy, zz));
            //Debug.Log(xx);
            //Debug.Log(yy);
            //Debug.Log(zz);

            //Debug.Log(a.position);
        }
    }
}
