using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeControll1 : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    public GameObject c;

    // Start is called before the first frame update

    
    public void Ropecontroll()
    {
        a.active = false;
        b.active = true;
        c.active = true;
        Destroy(c, 3);
        Debug.Log("¥Í¿Ω§∑§∑");
        
    }
}
