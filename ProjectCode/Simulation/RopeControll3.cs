using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RopeControll3 : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    public GameObject c;
    
    public GameObject e;
    public GameObject f;
    private float times;
    private bool check=false;

    public void RopeControl3()
    {
        e.active = false;
        a.GetComponent<RopeBuilder>().enabled = true;
        b.active= true;
        Destroy(b, 3);
        c.active = true;
        times += Time.deltaTime;
        Destroy(c, 3);
        Invoke("end", 3);
        
        
        
    }

    void end()
    {
        f.active = true;
        Debug.Log("엔딩컷이에요");
    }

    //private void Update()
    //{   
    //    if (c.active==true & check==false)
    //    {
    //        times += Time.deltaTime;
    //        if (times > 2.9 & check==false)
    //        {
    //            f.active = true;
    //            Debug.Log("엔딩컷이에요");
    //            check= true;
    //        }
    //    }
        
    //}
}
