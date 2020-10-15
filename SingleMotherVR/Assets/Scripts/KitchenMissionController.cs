using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenMissionController : MonoBehaviour
{
    [Header("Start")]
    public GameObject Particle;
    public Transform Avatar;
    public CharacterController AvatarController;
    public Vector3 StandingPos;
    private Transform Target;

    [Header("General")]
    public AudioSource RingingAudio;
    public AudioSource SpeakingAudio;
    public Animator TelephoneAnim;
    public GameObject Canvas;
    public GameObject Phone;
    public Button StartCallBtn;
    public Button EndCallBtn;

    private void Awake()
    {
        StartCallBtn.onClick.AddListener(()=> { StartCoroutine(StartCall()); });
        EndCallBtn.onClick.AddListener(()=> { StartCoroutine(EndCall()); });
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

        StartCoroutine(StartMission());
    }

    IEnumerator StartMission()
    {
        Particle.SetActive(false);
        AvatarController.enabled = false;
        Avatar.localPosition = StandingPos;

        yield return new WaitForSeconds(3);
        RingingAudio.enabled = true;
        Canvas.SetActive(true);

        yield return new WaitForSeconds(0.2f);
        TelephoneAnim.Play("TelephoneRinging");
    }

    IEnumerator StartCall()
    {
        TelephoneAnim.enabled = false;
        RingingAudio.enabled = false;
        Phone.SetActive(false);
        Canvas.GetComponent<Animator>().Play("CanvasGroupFadeOut");
        yield return new WaitForSeconds(0.6f);
        Canvas.SetActive(false);

        yield return new WaitForSeconds(0.6f);
        SpeakingAudio.enabled = true;
        yield return new WaitForSeconds(22.2f);
        Phone.SetActive(true);
    }

    IEnumerator EndCall()
    {
        TelephoneAnim.enabled = true;
        RingingAudio.enabled = false;
        Phone.SetActive(true);
        Canvas.GetComponent<Animator>().Play("CanvasGroupFadeOut");
        TelephoneAnim.Play("New State");
        yield return new WaitForSeconds(0.6f);
        Canvas.SetActive(false);

        yield return new WaitForSeconds(1);
        StartCoroutine(StartMission());
    }
}
