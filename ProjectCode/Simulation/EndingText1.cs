using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingText : MonoBehaviour
{
    public GameObject a;    // 활성화할 게임 오브젝트를 연결할 변수
    
    // 엔딩1을 실행하는 함수
    public void Ending1()
    {
        a.active = true;    // a에 연결된 게임 오브젝트를 활성화합니다.

    }
}
