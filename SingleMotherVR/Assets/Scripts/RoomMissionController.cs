using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMissionController : MonoBehaviour
{
    private Transform Target;
    private bool IsStarted = false;

    public GameObject MissionParticle;
    public GameObject MissionEndParticle;
    public CharacterController AvatarController;
    public Transform Avatar;
    public OVRScreenFade ScreenFade;
    public Vector3 StartingPos;
    public Vector3 StartingRot;
        
    void Start()
    {
        Target = Camera.main.transform;
        IsStarted = false;
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
        MissionParticle.SetActive(false);
        MissionEndParticle.SetActive(true);
        AvatarController.enabled = false;
        ScreenFade.FadeOut();
        yield return new WaitForSeconds(2.5f);
        Avatar.localPosition = StartingPos;
        Avatar.localRotation = Quaternion.Euler(StartingRot);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(ScreenFade.Fade(1, 0, value => {
            AvatarController.enabled = true;
        }));
    }

    void EndMission() {
        IsStarted = false;
        MissionParticle.SetActive(true);
        MissionEndParticle.SetActive(false);
    }
}
