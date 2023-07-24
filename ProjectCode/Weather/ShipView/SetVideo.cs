using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SetVideo : MonoBehaviour
{
    public GameObject videoFront;
    public GameObject videoSide1;
    public GameObject videoSide2;
    public GameObject videoBack;
    private List<GameObject> videoList;
    private List<string> urlList;
    int check = 4;
    private void Start()
    {
        videoList = new List<GameObject>() {videoFront, videoSide1, videoSide2, videoBack };
        foreach (GameObject video in videoList)
        {
            video.GetComponent<VideoPlayer>().SetDirectAudioVolume(0, 0);
        }

    }
    public void Front()
    {
        Activation(videoList, 0);
    }
    public void Side1()
    {
        Activation(videoList, 1);
    }
    public void Side2()
    {
        Activation(videoList, 2);
    }
    public void Back()
    {
        Activation(videoList, 3);
    }
    // 동영상 창 활성화 유무 결정
    private void Activation(List<GameObject> videoList, int SelectNum)
    {
        // 기존에 열려있는 창의 유무 확인 및 활성화 비활성화 체크
        if (videoList[SelectNum].GetComponent<MeshRenderer>().isVisible && (check == SelectNum))
        {
            // 오디오 볼륨 활성화
            videoList[SelectNum].GetComponent<VideoPlayer>().SetDirectAudioVolume(0, 0);
            videoList[SelectNum].GetComponent<MeshRenderer>().enabled = false;
            check = 4;
        }
        else
        {
            if (check < 4)
            {
                // 기존에 있던 오디오 및 동영상 비활성화
                videoList[check].GetComponent<MeshRenderer>().enabled = false;
                videoList[check].GetComponent<VideoPlayer>().SetDirectAudioVolume(0, 0);
            }
            // 선택한 영역의 볼륨 및 동영상 활성화
            videoList[SelectNum].GetComponent<VideoPlayer>().SetDirectAudioVolume(0, 1);
            videoList[SelectNum].GetComponent<MeshRenderer>().enabled = true;
            check = SelectNum;  // 현제 선택한 인덱스 저장
        }
    }
}
