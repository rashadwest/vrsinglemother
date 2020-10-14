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
    public Animator TelephoneAnim;
    public GameObject Canvas;
    public GameObject Phone;
    public Button StartCallBtn;

    private void Awake()
    {
        StartCallBtn.onClick.AddListener(StartCall);
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

        Particle.SetActive(false);
        AvatarController.enabled = false;
        Avatar.localPosition = StandingPos;

        StartCoroutine(StartMission());
    }

    IEnumerator StartMission() {
        yield return new WaitForSeconds(3);
        RingingAudio.enabled = true;
        Canvas.SetActive(true);

        yield return new WaitForSeconds(0.2f);
        TelephoneAnim.Play("TelephoneRinging");
    }

    void StartCall() {
        TelephoneAnim.enabled = false;
        RingingAudio.enabled = false;
        Canvas.GetComponent<Animator>().Play("CanvasGroupFadeOut");
        Phone.SetActive(false);
    }
}
