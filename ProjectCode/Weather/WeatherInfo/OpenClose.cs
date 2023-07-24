using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpenClose : MonoBehaviour
{
    public GameObject WeatherInfo;
    public GameObject gg;
    private int OpenQuad = 0;
    private void Start()
    {
        WeatherInfo.SetActive(false);
        gg.SendMessage("SeaInfo", "12C20210");
    }
    public void ActiveEastSea()
    {
        if (WeatherInfo.activeSelf && (OpenQuad == 1))
        {
            WeatherInfo.SetActive(false);
        }
        else
        {
            WeatherInfo.SetActive(true);
            gg.SendMessage("SeaInfo", "12C20210");
            OpenQuad = 1;
        }
    }
    public void ActiveUlSan()
    {
        if (WeatherInfo.activeSelf && (OpenQuad == 2))
        {
            WeatherInfo.SetActive(false);
        }
        else
        {
            WeatherInfo.SetActive(true);
            gg.SendMessage("SeaInfo", "12C10101");
            OpenQuad= 2;
        }
    }
    public void ActiveBuSan()
    {
        if (WeatherInfo.activeSelf && (OpenQuad == 3))
        {
            WeatherInfo.SetActive(false);
        }
        else
        {
            WeatherInfo.SetActive(true);
            gg.SendMessage("SeaInfo", "12B20103");
            OpenQuad = 3;
        }
    }
    public void ActiveGeoJe()
    {
        if (WeatherInfo.activeSelf && (OpenQuad == 4))
        {
            WeatherInfo.SetActive(false);
        }
        else
        {
            WeatherInfo.SetActive(true);
            gg.SendMessage("SeaInfo", "12B20104");
            OpenQuad = 4;
        }
    }
    public void ActiveInCheon()
    {
        if (WeatherInfo.activeSelf && (OpenQuad == 5))
        {
            WeatherInfo.SetActive(false);
        }
        else
        {
            WeatherInfo.SetActive(true);
            gg.SendMessage("SeaInfo", "12A20102");
            OpenQuad = 5;
        }
    }
}
