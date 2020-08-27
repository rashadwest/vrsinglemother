using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VideoPicker : MonoBehaviour
{
    private string[] VideoUrls = new string[4] { "https://dm0qx8t0i9gc9.cloudfront.net/watermarks/videoNIHmZbghlilb1qj7b/videoblocks-clouds-timelapse-at-sunset-in-virtual-reality-360-degree-video_H_ktSMVjg__ea02260e9e36490663ad9ef39b4e55d4__P640.mp4", "https://v.ftcdn.net/02/56/29/09/700_F_256290901_VRFn0S1HA8HicgtADGXK8plEnyLu0ZVL_ST.mp4", "https://v.ftcdn.net/02/01/24/15/700_F_201241589_kJeZ5a0D3TDNCuLDrtG6fwIKM3E5VuX5_ST.mp4", "https://v.ftcdn.net/02/84/63/26/700_F_284632697_ituINP5ktQH0gsVhXrJftC6btIK7O1rw_ST.mp4" };

    public Button CloseBtn;

    public Transform Avatar;

    private Vector3 AvatarPos;

    private void Awake()
    {
        CloseBtn.onClick.AddListener(Close);
    }

    private void Start()
    {
        if (PlayerPrefs.GetString("AvatarPos") != "")
        {
            string[] avatarPos = PlayerPrefs.GetString("AvatarPos").Trim('(').Trim(')').Split(',');
            var x = float.Parse(avatarPos[0]);
            var y = float.Parse(avatarPos[1].Trim(' '));
            var z = float.Parse(avatarPos[2].Trim(' '));

            AvatarPos = new Vector3(x, y, z);
            Avatar.localPosition = AvatarPos;
        }
    }

    public void PickVideo() {
        PlayerPrefs.SetString("AvatarPos", Avatar.localPosition.ToString());
        int videoId = Random.Range(1, 5);
        string videoUrl = VideoUrls[videoId-1];

        PlayerPrefs.SetString("VideoUrl", videoUrl);

        SceneManager.LoadScene("VideoScene");
    }

    void Close()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
