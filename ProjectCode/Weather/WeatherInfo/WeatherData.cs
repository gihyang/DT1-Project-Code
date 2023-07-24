using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;
using System.Text.RegularExpressions; //정규식
using UnityEngine.Networking;
using System.Text;
using TMPro;
using System.Linq;

public class WeatherData : MonoBehaviour
{
    private string url;
    private List<StringBuilder> data;
    public GameObject tmpTime;
    public GameObject tmpWindDirection;
    public GameObject tmpWindSpeed;
    public GameObject tmpSignificantWave;
    public GameObject tmpSkyState;
    public GameObject tmpInfo;
    public GameObject tmpSourceInfo;
    // Start is called before the first frame update
    public void SeaInfo(string location)
    {
        DateTime currentTime = DateTime.Now;
        DateTime futureTime = currentTime.AddDays(4);
        string date1 = $"{currentTime.ToString("yyyyMMdd")}00";
        string date2 = $"{futureTime.ToString("yyyyMMdd")}00";
        data = new List<StringBuilder>();
        string url = $"http://apihub.kma.go.kr/api/typ01/url/fct_afs_do.php?reg=&tmfc1={currentTime.ToString("yyyyMMdd")}00&tmfc2={futureTime.ToString("yyyyMMdd")}00&disp=0&help=1&authKey=lY2IAXPgQdCNiAFz4BHQbQ";
        StartCoroutine(FetchData(url, location, date1, date2));
    }
    
    IEnumerator FetchData(string URL, string location, string date1, string date2   )
    {
        List<StringBuilder> dataset = new List<StringBuilder>() { new StringBuilder(), new StringBuilder(), new StringBuilder(), new StringBuilder(), new StringBuilder() };
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {

            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                string response = request.downloadHandler.text;

                // Extract the data for specific codes
                string[] codesToRetrieve = { "12B20104", "12C10101", "12C20210", "12A20102", "12B20103" };
                Dictionary<string, List<string>> retrievedData = ExtractDataForCodes(response, codesToRetrieve);
                // Log the retrieved data
                foreach (KeyValuePair<string, List<string>> kvp in retrievedData)
                {
                    int cnt = 0;
                    foreach (string line in kvp.Value)
                    {
                        dataset = classfication(line, location, dataset);
                        cnt++;
                        if (cnt == 8) { break; }
                    }
                }
                tmpTime.GetComponent<TextMeshPro>().text = dataset[0].ToString();
                tmpWindDirection.GetComponent<TextMeshPro>().text = dataset[1].ToString();
                tmpWindSpeed.GetComponent<TextMeshPro>().text = dataset[2].ToString();
                tmpSignificantWave.GetComponent<TextMeshPro>().text = dataset[3].ToString();
                tmpSkyState.GetComponent<TextMeshPro>().text = dataset[4].ToString();
                tmpInfo.GetComponent<TextMeshPro>().text = $"{date1.Substring(0, 4)}.{date1.Substring(4,2)}.{date1.Substring(6,2)} {date1.Substring(8,2)}시 ~ " +
                    $"{date2.Substring(0, 4)}.{date2.Substring(4, 2)}.{date2.Substring(6, 2)} {date2.Substring(8, 2)}시 사이 조회 된 4일 간의 해상예보 입니다.";
                tmpSourceInfo.GetComponent<TextMeshPro>().text = $"자료 출처: 기상청API허브({URL })"; 
            }
            else
            {
                Debug.LogError("Failed to fetch data. Error: " + request.error);
            }
        }
        
    }

    Dictionary<string, List<string>> ExtractDataForCodes(string response, string[] codesToRetrieve)
    {
        Dictionary<string, List<string>> dataDictionary = new Dictionary<string, List<string>>();

        string[] lines = response.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string line in lines)
        {
            if (line.StartsWith("#") || string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts = line.Split(' ');
            if (parts.Length >= 2)
            {
                string code = parts[0];
                string data = line;

                if (Array.Exists(codesToRetrieve, x => x == code))
                {
                    if (dataDictionary.ContainsKey(code))
                    {
                        dataDictionary[code].Add(data);
                    }
                    else
                    {
                        List<string> dataList = new List<string>();
                        dataList.Add(data);
                        dataDictionary[code] = dataList;
                    }
                }
            }
        }

        return dataDictionary;
    }

    private List<StringBuilder> classfication(string data, string locationNum,List<StringBuilder> datasets)
    {
        
        string[] infos = data.Split(' ');
        if (infos[0] == locationNum)
        {
            datasets[0] = datasets[0].Append($"{data.Substring(22,4)}.{data.Substring(26,2)}.{data.Substring(28,2)}\n{data.Substring(30,2)}h\r\n");
            datasets[1] = datasets[1].Append($"{data.Substring(69,2)}\r\n\r\n");
            datasets[2] = datasets[2].Append($"{data.Substring(78, 2)}~{data.Substring(80, 2)}m/s\r\n\r\n");
            datasets[3] = datasets[3].Append($"{data.Substring(84, 3)}~{data.Substring(89, 3)}m\r\n\r\n");
            datasets[4] = datasets[4].Append($"{data.Substring(103)}\r\n\r\n");
        }
        return datasets;
    }
}