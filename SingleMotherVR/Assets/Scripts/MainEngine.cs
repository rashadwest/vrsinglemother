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
    public PostProcessingEffects PostProcessingEffects;
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
    public AudioSource RememberAudio;
    public AudioSource EnjoingAudio;

    private void Awake()
    {
        BeachSceneBtn.onClick.AddListener(() => { StartCoroutine(OpenBeachScene());  });
        JailSceneBtn.onClick.AddListener(()=> { StartCoroutine(OpenJailScene()); });
    }

    IEnumerator Start()
    {
        if (PlayerPrefs.GetString("BankAccaunt") == "")
        {
            PlayerPrefs.SetString("BankAccaunt", "350");
        }

        EyeCanvas.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);

        TimeController.SetTime();

        PostProcessingEffects.SetValuesZero();

        if (PlayerPrefs.GetString("AvatarPos") != "")
        {
            AvatarController.enabled = false;
            string[] avatarPos = PlayerPrefs.GetString("AvatarPos").Trim('(').Trim(')').Split(',');
            var x = float.Parse(avatarPos[0]);
            var y = float.Parse(avatarPos[1].Trim(' '));
            var z = float.Parse(avatarPos[2].Trim(' '));

            AvatarPos = new Vector3(x, y, z);
            Avatar.localPosition = AvatarPos;
            AvatarController.enabled = true;


            EnjoingAudio.enabled = true;
            yield return new WaitForSeconds(4.3f);
            EnjoingAudio.enabled = false;
        }
        else
        {

        }
    }

    public IEnumerator SittingSofa()
    {
        Avatar.localPosition = SitPosition;
        Avatar.LookAt(TV);
        AvatarController.enabled = false;
        AvatarChild.localPosition = new Vector3(0,0.13f,0);
        yield return new WaitForSeconds(0.2f);
        AvatarController.enabled = true;

        //EyeCanvas.gameObject.SetActive(true);
    }

    public void GoToMenu() {
        StartCoroutine(ScreenFade.Fade(0, 1, value => {
            SceneManager.LoadScene("MenuScene");
        })); 
    }

    IEnumerator OpenBeachScene() {
        Debug.Log("Open Beach Scene");

        PlayerPrefs.SetString("AvatarPos", Avatar.localPosition.ToString());

        PostProcessingEffects.PlayToOne();

        RememberAudio.enabled = true;
        yield return new WaitForSeconds(3);
        RememberAudio.enabled = false;
        
        StartCoroutine(ScreenFade.Fade(0, 1, value => {
            SceneManager.LoadScene("Beach");
        }));
    }

    IEnumerator OpenJailScene()
    {
        Debug.Log("Open Jail Scene");

        PlayerPrefs.SetString("AvatarPos", Avatar.localPosition.ToString());

        PostProcessingEffects.PlayToOne();

        RememberAudio.enabled = true;
        yield return new WaitForSeconds(3);
        RememberAudio.enabled = false;
        
        StartCoroutine(ScreenFade.Fade(0, 1, value => {
            SceneManager.LoadScene("Jail");
        }));
    }
}
