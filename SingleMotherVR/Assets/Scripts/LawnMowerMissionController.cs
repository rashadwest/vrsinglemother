using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnMowerMissionController : MonoBehaviour
{
    public GameObject LawnMawerPrefab;
    public Transform LawnMawerParent;
    public Transform Avatar;
    public CharacterController AvatarController;
    public Vector3 StartingPosition;

    public AudioSource LawnMower1;
    public AudioSource LawnMower2;

    private Transform Cam;
    private GameObject LawnMawer;

    private void Start()
    {
        Cam = Camera.main.transform;

        LawnMower1.enabled = false;
        LawnMower2.enabled = false;

        StartMission();
    }

    void StartMission() {
        AvatarController.enabled = false;
        Avatar.localPosition = StartingPosition;
        AvatarController.enabled = true;
        LawnMawer = Instantiate(LawnMawerPrefab, LawnMawerParent);
        StartCoroutine(PlayAudio());
    }

    private void Update()
    {
        if (LawnMawer == null)
            return;

        LawnMawer.transform.localEulerAngles = new Vector3(0, Cam.localEulerAngles.y, 0);


    }

    IEnumerator PlayAudio() {
        LawnMower1.enabled = true;
        yield return new WaitForSeconds(LawnMower1.clip.length - 0.5f);
        LawnMawer.transform.GetChild(0).GetComponent<Animator>().Play("LawnMower");
        LawnMower1.enabled = false;
        LawnMower2.enabled = true;
    }
}
