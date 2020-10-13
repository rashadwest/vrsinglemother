using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BedLieEvent : MonoBehaviour
{
    private Transform Target;

    public Transform Avatar;

    public CharacterController AvatarController;

    public Vector3 LiePosition;
    public Vector3 WakeUpPosition;

    public ShiningEffect ShiningEffect;

    public Button WakeUpBtn;

    public GameObject Canvas;
    public GameObject DoorShiningCanvas;

    public OVRScreenFade ScreenFade;

    [Header("Door")]
    public Button DoorBtn;

    public Animator DoorAnim;

    private void Awake()
    {
        WakeUpBtn.onClick.AddListener(WakeUp);
        DoorBtn.onClick.AddListener(OpenJailDoor);
    }

    private void Start()
    {
        Target = Camera.main.transform;
        Canvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != Target)
            return;

        AvatarController.enabled = false;
        ShiningEffect.enabled = false;
        DoorShiningCanvas.SetActive(true);
        Avatar.localPosition = LiePosition;
        Canvas.SetActive(true);
    }

    void WakeUp() {
        Avatar.localPosition = WakeUpPosition;
        Canvas.SetActive(false);
        AvatarController.enabled = true;
        ShiningEffect.enabled = true;
        DoorShiningCanvas.SetActive(true);
    }

    void OpenJailDoor() {
        DoorShiningCanvas.SetActive(false);
        DoorAnim.Play("JailDoorAnim");

        StartCoroutine(ScreenFade.Fade(0, 1, value => {
            if (PlayerPrefs.GetString("Time") == "Day")
            {
                PlayerPrefs.SetString("Time", "Night");
            }
            else
            {
                PlayerPrefs.SetString("Time", "Day");
            }

            SceneManager.LoadScene("Environment");
        }));
    }
}
