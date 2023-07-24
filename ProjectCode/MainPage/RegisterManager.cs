using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegisterManager : MonoBehaviour
{
    // 사용자 입력을 받을 TMP_InputField 변수들을 선언합니다.
    public TMP_InputField UserIdInputField;        // 사용자 아이디 입력 필드
    public TMP_InputField PasswordInputField;      // 비밀번호 입력 필드
    public TMP_InputField CheckPasswordInputField; // 비밀번호 확인 입력 필드
    public TMP_InputField EmailInputField;         // 이메일 입력 필드
    public TMP_InputField ValidationInputField;    // 유효성 검사 입력 필드
    public TMP_InputField NameInputField;          // 사용자 이름 입력 필드
    public TMP_InputField GenderInputField;        // 성별 입력 필드
    public TMP_InputField DepartmentInputField;    // 부서 입력 필드
    public TMP_InputField RoleInputField;          // 역할 입력 필드

    // 사용자 등록에 필요한 정보들을 담을 변수들을 선언합니다.
    string userid;
    string userpw;
    string checkuserpw;
    string email;
    string validation;
    string username;
    string gender;
    string department;
    string role;
    // 서버에 등록 요청을 보낼 URL을 설정합니다.
    string registerUrl = "http://hololens-wjqcg.run.goorm.site/register";

    // Start() 함수는 스크립트가 활성화될 때 실행됩니다.
    private void Start()
    {
        // 테스트용으로 미리 입력 필드들에 값들을 설정합니다.
        UserIdInputField.text = "admin";
        PasswordInputField.text = "1234";
        CheckPasswordInputField.text = "1234";
        ValidationInputField.text = "123456";
        EmailInputField.text = "gihyang@samsungshi.com";
        NameInputField.text = "김지향";
        GenderInputField.text = "Female";
        DepartmentInputField.text = "AI Development";
        RoleInputField.text = "Intern";
    }

    // 사용자 등록 버튼을 클릭했을 때 호출되는 함수입니다.
    public void RegisterBtn()
    {
        userid = UserIdInputField.text;
        userpw = PasswordInputField.text;
        checkuserpw = CheckPasswordInputField.text;
        email = EmailInputField.text;
        validation = ValidationInputField.text;
        username = NameInputField.text;
        gender = GenderInputField.text;
        department = DepartmentInputField.text;
        role = RoleInputField.text;

        // 서버에 데이터를 전송하는 Coroutine 함수를 실행합니다
        StartCoroutine(PostData(userid, userpw, checkuserpw, email, validation, username, gender, department, role));
    }

    // 서버에 데이터를 전송하는 Coroutine 함수입니다.
    public IEnumerator PostData(string userid, string userpw, string checkuserpw, string email, string validation, string username, string gender, string department, string role)
    {
        // WWWForm을 사용하여 서버에 전송할 데이터를 설정합니다.
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);
        form.AddField("userpw", userpw);
        form.AddField("checkuserpw", checkuserpw);
        form.AddField("email", email);
        form.AddField("validation", validation);
        form.AddField("username", username);
        form.AddField("gender", gender);
        form.AddField("department", department);
        form.AddField("role", role);

        // 지정된 URL로 POST 요청을 보냅니다.
        var www = new WWW(registerUrl, form);
        yield return www;

        // 서버 응답을 확인하고, 오류가 없으면 등록 성공 메시지를 출력하고 LoginScene을 로드합니다.
        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Registration successful!");

            SceneManager.LoadScene("LoginScene");
        }
        else
        {
            // 오류가 발생한 경우 오류 메시지를 출력합니다.
            Debug.Log("Registration error: " + www.error);
        }
    }

    public void Back()
    {
        // LoginScene을 로드합니다.
        SceneManager.LoadScene("01.Scenes/Main/LoginScene");
    }
}
