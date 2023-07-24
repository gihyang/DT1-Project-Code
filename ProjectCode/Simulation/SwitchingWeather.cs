using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwitchingWeather : MonoBehaviour
{
    public GameObject rainfall;
    public TMP_Text tt;
    public void RainDrop()
    {
        if(rainfall.active==false)
        {
            rainfall.SetActive(true);
            tt.text = "Sunny";
        }
        else
        {
            rainfall.SetActive(false);
            tt.text = "Rainy";
        }
    }
}
