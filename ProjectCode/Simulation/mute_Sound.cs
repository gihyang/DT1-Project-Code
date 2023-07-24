using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mute_Sound : MonoBehaviour
{
    public GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ShutDown",2);
    }

    // Update is called once per frame
    void ShutDown()
    {
        a.SetActive(false);
    }
}
