using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using UnityEngine.UI;

public class AuthManager : MonoBehaviour
{
    // 사용자로부터 입력 받을 TMP_InputField 변수들을 선언합니다.
    public TMP_InputField UserIdInputField;     // 사용자 아이디 입력 필드
    public TMP_InputField PasswordInputField;   // 비밀번호 입력 필드

    // 로그인 상태 등을 표시하기 위한 TMP_Text 변수를 선언합니다.
    public TMP_Text notice;

    // 사용자 아이디와 비밀번호를 저장할 변수들을 선언합니다.
    string userid;
    string userpw;
    // 서버로 요청을 보낼 URL을 설정합니다.
    string url = "http://hololens-wjqcg.run.goorm.site/login";

    // 로그인 버튼을 클릭했을 때 호출되는 함수입니다.
    public void LoginBtn()
    {
        // 사용자로부터 입력된 아이디와 비밀번호를 가져옵니다.
        userid = "admin";
        userpw = "1234";

        // 서버로부터 로그인 정보를 확인하는 Coroutine 함수를 실행합니다.
        StartCoroutine(GetData());
    }

    // 서버로부터 로그인 정보를 확인하는 Coroutine 함수입니다.
    public IEnumerator GetData()
    {
        WWWForm form = new WWWForm();    // 객체 생성
        
        // 통신을 위한 프로토콜에 사용자 아이디, 비밀번호 추가
        form.AddField("userid", userid); 
        form.AddField("userpw", userpw);

        // 지정된 URL로 POST 요청을 보냅니다.
        var www = new WWW(url, form);
        yield return www;   // 서버 응답을 기다립니다

        // 서버와 통신이 성공적으로 이루어진 경우
        if (string.IsNullOrEmpty(www.error))
        {
            // 서버에서 받은 JSON 데이터를 JObject로 파싱합니다.
            JObject jobject = JObject.Parse(www.text);
            // 서버에서 받은 status 값에 따라 로그인 성공 여부를 확인합니다.
            // status = 1이면 로그인 성공, status = 0이면 로그인 실패
            if (jobject["status"].ToString() == "1")
            {
                Debug.Log("로그인 성공");

                // 로그인에 성공하면 MainPageScene으로 이동합니다.
                SceneManager.LoadScene("01.Scenes/Main/MainPageScene");
            }
            // 2) status = 0이면 로그인 실패한 것
            else
            {
                // 로그인에 실패한 경우, 서버에서 받은 오류 메시지를 출력합니다.
                Debug.Log(jobject["msg"].ToString());
            }
        }
        else
        {
            // 서버와 통신 중 오류가 발생한 경우, 오류 메시지를 출력합니다.
            Debug.Log("Error:" + www.error);
        }
    }

// 회원가입 버튼을 클릭했을 때 호출되는 함수입니다.
    public void RegisterBtn()
    {
        // RegisterScene으로 이동합니다.
        SceneManager.LoadScene("01.Scenes/Main/RegisterScene");
    }
    
    // 비밀번호 변경 버튼을 클릭했을 때 호출되는 함수입니다.
    public void ChangePasswordBtn()
    {
        // ChangePasswordScene으로 이동합니다.
        SceneManager.LoadScene("01.Scenes/Main/ChangePasswordScene");
    }


}