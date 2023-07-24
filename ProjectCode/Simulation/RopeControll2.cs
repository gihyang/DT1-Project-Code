using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeControll2 : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    public GameObject c;

    public void RopeControl2()
    {
        a.GetComponent<Rope2>().enabled = true;
        b.active=true;
        Destroy(b, 3);
        c.active = false;
    }
}
