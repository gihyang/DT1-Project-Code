using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_of_music : MonoBehaviour
{

    public GameObject a3;
    public GameObject a2;
    public GameObject a1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void SSory3()
    {

        a3.SetActive(true);
    }
    public void SSory2()
    {

        a2.SetActive(true);
    }
    public void SSory1()
    {

        a1.SetActive(true);
    }
}
