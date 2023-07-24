using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeTool3 : MonoBehaviour
{
    public GameObject a;
    // Start is called before the first frame update


    // Update is called once per frame
    public void RopeToolmaker()
    {
        a.active = true;
        Debug.Log("눌러졌어요");
    }
}


