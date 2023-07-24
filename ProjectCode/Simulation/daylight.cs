using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class daylight : MonoBehaviour
{


    public Material dayMat;
    public Material sunsetMat;
    public Material cloudyMat;
    public Material rainyMat;


    public GameObject dayLight;
    public GameObject sunsetLight;
    public GameObject cloudyLight;
    public GameObject rainyLight;

    public Color dayFog;
    public Color sunsetFog;
    public Color cloudyFog;
    public Color rainyFog;

    public bool playRain = true; //비 오는 파티클 재생 여부를 제어하는 bool 변수
    public ParticleSystem particleObject; // 비 오는 파티클 시스템

    //번개 관련 변수
    public bool ohyeah = false; // 번개가 발생하는지 여부를 저장하는 변수


    private void Start()
    {
        playRain = false;   // 비 오는 파티클 재생 여부를 기본적으로 false로 설정합니다.

        if (playRain)
            particleObject.Play();
        else if (!playRain)
            particleObject.Stop();
    }

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1.0f);  // 하늘 회전 효과를 설정합니다.



    }

    private void OnGUI()
    {
        // GUI 버튼들을 통해 각 상태별로 머티리얼, 조명, 안개 색상 등을 변경합니다.
        // 버튼 클릭시 해당 상태로 전환됩니다.
        if (GUI.Button(new Rect(5, 5, 80, 20), "Day"))
        {
            RenderSettings.skybox = dayMat;
            RenderSettings.fogColor = dayFog;
            dayLight.SetActive(true);
            sunsetLight.SetActive(false);
            cloudyLight.SetActive(false);
            rainyLight.SetActive(false);
            playRain = false;
            if (playRain)
                particleObject.Play();
            else if (!playRain)
                particleObject.Stop();
            Invoke("DestoryThunder", 0.0f);
            ohyeah = false;

        }
        if (GUI.Button(new Rect(5, 35, 80, 20), "Sunset"))
        {
            RenderSettings.skybox = sunsetMat;
            RenderSettings.fogColor = sunsetFog;
            dayLight.SetActive(false);
            sunsetLight.SetActive(true);
            cloudyLight.SetActive(false);
            rainyLight.SetActive(false);
            playRain = false;
            if (playRain)
                particleObject.Play();
            else if (!playRain)
                particleObject.Stop();
            Invoke("DestoryThunder", 0.0f);
            ohyeah = false;
        }
        if (GUI.Button(new Rect(5, 65, 80, 20), "Cloudy"))
        {

            RenderSettings.skybox = cloudyMat;
            RenderSettings.fogColor = cloudyFog;
            dayLight.SetActive(false);
            sunsetLight.SetActive(false);
            cloudyLight.SetActive(true);
            rainyLight.SetActive(false);
            playRain = false;
            if (playRain)
                particleObject.Play();
            else if (!playRain)
                particleObject.Stop();
            Invoke("DestoryThunder", 0.0f);
            ohyeah = false;
        }

        if (GUI.Button(new Rect(5, 95, 80, 20), "Rainy"))
        {
            RenderSettings.skybox = rainyMat;
            RenderSettings.fogColor = rainyFog;
            dayLight.SetActive(false);
            sunsetLight.SetActive(false);
            cloudyLight.SetActive(false);
            rainyLight.SetActive(true);

            playRain = true;
            if (playRain)
                particleObject.Play();
            else if (!playRain)
                particleObject.Stop();
            Invoke("DestoryThunder", 0.0f);
            ohyeah = false;


        }
        if (GUI.Button(new Rect(5, 125, 80, 20), "Thunder"))
        {
            RenderSettings.skybox = rainyMat;
            RenderSettings.fogColor = rainyFog;
            dayLight.SetActive(false);
            sunsetLight.SetActive(false);
            cloudyLight.SetActive(false);
            rainyLight.SetActive(true);

            playRain = true;
            if (playRain)
                particleObject.Play();
            else if (!playRain)
                particleObject.Stop();
            ohyeah = true;

            InvokeRepeating("MakeThunder", 3.0f, 12.0f);
            InvokeRepeating("DestoryThunder", 4.0f, 12.0f);


        }

    }

    // 번개 이펙트를 활성화하는 함수
    void MakeThunder()
    {
        if (ohyeah)
        {

            RenderSettings.ambientIntensity = 8f;
        }

    }

    // 번개 이펙트를 비활성화하는 함수
    void DestoryThunder()
    {
        if (ohyeah)
        {

            RenderSettings.ambientIntensity = 1f;
        }
    }

}