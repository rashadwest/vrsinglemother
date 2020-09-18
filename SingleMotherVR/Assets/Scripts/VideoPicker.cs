using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VideoPicker : MonoBehaviour
{
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

    void Close()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
