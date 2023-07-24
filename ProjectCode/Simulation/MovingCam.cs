using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MovingCam : MonoBehaviour
{
    public static Transform CameraMoving;   // 다른 스크립트에서 카메라의 Transform 컴포넌트를 참조할 수 있도록 정적 변수로 선언합니다.

    // Start is called before the first frame update
    void Start()
    {
        CameraMoving = GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(CameraMoving.eulerAngles.x);  // 카메라의 X 축 회전값을 출력합니다.
    }
}
