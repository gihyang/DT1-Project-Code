using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void GoToShipScene()
    {
        SceneManager.LoadScene("01.Scenes/Weather/Ship");
    }
    public void GoToWeatherScene()
    {
        SceneManager.LoadScene("01.Scenes/Weather/WeatherInfo");
    }
    public void GoToWeatherMainScene()
    {
        SceneManager.LoadScene("01.Scenes/Weather/Main Scene");
    }
    public void GoToMainSelectScene()
    {
        SceneManager.LoadScene("01.Scenes/Main/MainPageScene");
    }
    public void GoToSimul()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    public void GoToLogin()
    {
        SceneManager.LoadScene("01.Scenes/Main/LoginScene");
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}