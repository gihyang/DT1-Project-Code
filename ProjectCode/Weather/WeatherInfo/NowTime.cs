using Microsoft.MixedReality.Toolkit;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NowTime : MonoBehaviour
{
    // 시간데이터 저장할 GameObject
    public GameObject TmpNowTime;
    
    void Update()
    {
        // Frame마다 현재 시간을 호출
        DateTime NowTime = DateTime.Now;
        // DateTime 데이터 형태를 문자열로 변환하여 TMP에 저장
        TmpNowTime.GetComponent<TextMeshPro>().text = NowTime.ToString();
    }

}
