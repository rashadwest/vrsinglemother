using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnMowerMissionController : MonoBehaviour
{
    public bool CanStart = false;

    [Space(10)]

    public GameObject LawnMawerPrefab;
    public Transform LawnMawerParent;
    public Transform Avatar;
    public CharacterController AvatarController;
    public GrassController GrassController;
    public Vector3 StartingPosition;

    public AudioSource LawnMower1;
    public AudioSource LawnMower2;

    private Transform Cam;
    private GameObject LawnMawer;


    private IEnumerator Start()
    {
        Cam = Camera.main.transform;

        LawnMower1.enabled = false;
        LawnMower2.enabled = false;

        if (CanStart)
        {
            StartMission();
            yield return new WaitForSeconds(1);
            GrassController.Enable();
        }
        else
        {
            GrassController.Disable();
        }
    }

    public IEnumerator Starting()
    {
        StartMission();
        yield return new WaitForSeconds(4);
        GrassController.Enable();
        
    }

    public void Ending() {
        Destroy(LawnMawer.gameObject);
        LawnMower1.Stop();
        LawnMower2.Stop();
        GrassController.Disable();
    }

    void StartMission() {
        AvatarController.enabled = false;
        //Avatar.localPosition = StartingPosition;
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
        LawnMower1.Play();
        yield return new WaitForSeconds(LawnMower1.clip.length - 0.5f);
        LawnMawer.transform.GetChild(0).GetComponent<Animator>().Play("LawnMower");
        AvatarController.enabled = true;
        LawnMower1.enabled = false;
        LawnMower2.enabled = true;
        LawnMower2.Play();
    }
}
