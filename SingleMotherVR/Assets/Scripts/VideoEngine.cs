using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VideoEngine : MonoBehaviour
{
    public MediaPlayer VideoPlayer;

    public Button CloseBtn;


    private void Awake()
    {
        CloseBtn.onClick.AddListener(Close);
    }

    void Start()
    {
        PlayVideo();
    }

    void PlayVideo() {
        string videoUrl = PlayerPrefs.GetString("VideoUrl");
        VideoPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.AbsolutePathOrURL, videoUrl, true);
    }

    void Close()
    {
        SceneManager.LoadScene("Environment");
    }
}
