using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTvVideos : MonoBehaviour
{
    public MediaPlayer VideoPlayer;

    public List<string> VideoUrls = new List<string>();

    void Start()
    {
        StartCoroutine(PlayVideos());
    }

    IEnumerator PlayVideos() {
        foreach (string url in VideoUrls)
        {
            VideoPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, url);
            yield return new WaitForSeconds(1);
            int waitTime = (int)VideoPlayer.Info.GetDurationMs() / 1000;
            yield return new WaitForSeconds(waitTime - 1);
        }
        
        StartCoroutine(PlayVideos());
    }

    void Update()
    {
    }
}
