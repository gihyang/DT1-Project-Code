using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MainPageManager : MonoBehaviour
{
    public string url = "http://hololens-wjqcg.run.goorm.site/register";
    public TMPro.TextMeshPro my_username;
    public TMPro.TextMeshPro my_email;

    private void Start()
    {
        StartCoroutine(FetchDataFromServer());
    }

    private IEnumerator FetchDataFromServer()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            Debug.Log(www.result.ToString());
            if (www.result != UnityWebRequest.Result.Success)
            {
                // Debug.LogError("Error while fetching data: " + www.error);
            }
            else
            {
                string jsonResponse = www.downloadHandler.text;
                ProcessData(jsonResponse);
            }
        }
    }

    private void ProcessData(string jsonResponse)
    {
        // Parse the JSON data into a JObject
        JObject jsonObject = JObject.Parse(jsonResponse);

        // Extract the specific data you want from the JObject
        string username = jsonObject["username"].Value<string>();
        string email = jsonObject["email"].Value<string>();

        // Display the data in the respective TextMeshPro components
        my_username.text = "Username: " + username;
        my_email.text = "Email: " + email;
    }

    public void Logout()
    {
        SceneManager.LoadScene("01.Scenes/Main/LoginScene");
    }
}
