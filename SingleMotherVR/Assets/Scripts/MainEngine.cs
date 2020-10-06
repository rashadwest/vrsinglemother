using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainEngine : MonoBehaviour
{
    [Header("General")]
    public Transform Avatar;
    public OVRScreenFade ScreenFade;
    public DayNightSystemController TimeController;

    private Vector3 AvatarPos;

    [Header("Sofa Sitting Part")]
    public Transform TV;
    public Transform AvatarChild;
    public CharacterController AvatarController;
    public Vector3 SitPosition;
    public GameObject EyeCanvas;
    public Animator EyeAnimation;
    public float distanceToCamera = 20f;
    private float camHeight;

    [Header("Painting Parts")]
    public Button BeachSceneBtn;
    public Button JailSceneBtn;

    private void Awake()
    {
        BeachSceneBtn.onClick.AddListener(OpenBeachScene);
        JailSceneBtn.onClick.AddListener(OpenJailScene);
    }

    private void Start()
    {
        EyeCanvas.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);

        TimeController.SetTime();

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

    public void SittingSofa()
    {
        Avatar.localPosition = SitPosition;
        Avatar.LookAt(TV);
        AvatarController.enabled = false;
        AvatarChild.localPosition = new Vector3(0,0,0);

        EyeCanvas.gameObject.SetActive(true);
    }

    public void GoToMenu() {
        StartCoroutine(ScreenFade.Fade(0, 1, value => {
            SceneManager.LoadScene("MenuScene");
        })); 
    }

    void OpenBeachScene() {
        Debug.Log("Open Beach Scene");

        StartCoroutine(ScreenFade.Fade(0, 1, value => {
            SceneManager.LoadScene("Beach");
        }));
    }

    void OpenJailScene()
    {
        Debug.Log("Open Jail Scene");

        StartCoroutine(ScreenFade.Fade(0, 1, value => {
            SceneManager.LoadScene("Jail");
        }));
    }
}
