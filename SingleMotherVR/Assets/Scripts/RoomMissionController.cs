using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMissionController : MonoBehaviour
{
    private Transform Target;
    private bool IsStarted = false;

    public GameObject OpenedWardrobe;
    public GameObject ClosedWardrobe;
    public GameObject MissionParticle;
    public GameObject MissionEndParticle;
    public CharacterController AvatarController;
    public Transform Avatar;
    public OVRScreenFade ScreenFade;
    public Vector3 StartingPos;
    public Vector3 StartingRot;
    public AudioSource CryingBabyAudio;

    public Transform CanvasContainer;
    public GameObject Canvas;
    public Text CanvasText;
        
    void Start()
    {
        Target = Camera.main.transform;
        IsStarted = false;
        OpenedWardrobe.SetActive(false);
        ClosedWardrobe.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != Target)
            return;

        if (!IsStarted)
        {
            StartCoroutine(StartMission());
        }
        else
        {
            EndMission();
        }
    }

    IEnumerator StartMission() {
        IsStarted = true;
        OpenedWardrobe.SetActive(true);
        ClosedWardrobe.SetActive(false);
        MissionParticle.SetActive(false);
        MissionEndParticle.SetActive(true);
        AvatarController.enabled = false;
        ScreenFade.FadeOut();
        yield return new WaitForSeconds(2.5f);
        Avatar.localPosition = StartingPos;
        Avatar.localRotation = Quaternion.Euler(StartingRot);
        CryingBabyAudio.volume = 0;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(ScreenFade.Fade(1, 0, value => {
            AvatarController.enabled = true;
        }));
    }

    void EndMission()
    {
        IsStarted = false;
        CryingBabyAudio.volume = 0.071f;
        OpenedWardrobe.SetActive(false);
        ClosedWardrobe.SetActive(true);
        MissionParticle.SetActive(true);
        MissionEndParticle.SetActive(false);
    }

    public void GetSignal() {
        OpenedWardrobe.SetActive(false);
        ClosedWardrobe.SetActive(true);
        StartCoroutine(ShowSuccessText());
    }

    IEnumerator ShowSuccessText() {
        Canvas.SetActive(true);
        CanvasContainer.localRotation = Quaternion.Euler(0, Camera.main.transform.localEulerAngles.y, 0);
        CanvasText.text = "Nice. You can leave the room";
        yield return new WaitForSeconds(3);
        Canvas.SetActive(false);
        CanvasText.text = "";
    }
}
