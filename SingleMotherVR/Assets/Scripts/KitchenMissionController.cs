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
    public GameObject LabelCanvas;
    public Text LabelText;

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
        StartCoroutine(PlaySubtitles());
        yield return new WaitForSeconds(22.2f);
        Phone.SetActive(true);
        LabelCanvas.GetComponent<Animator>().Play("CanvasGroupFadeOut");
        yield return new WaitForSeconds(0.6f);
        LabelCanvas.SetActive(false);
    }

    IEnumerator PlaySubtitles() {
        LabelCanvas.SetActive(true);
        LabelCanvas.GetComponent<Animator>().Play("CanvasGroupFadeIn");

        LabelText.color = Color.white;
        LabelText.text = "Hello...";
        yield return new WaitForSeconds(1.8f);
        LabelText.text = "Hello, i am Bill Collector";
        yield return new WaitForSeconds(2f);
        LabelText.text = "You have not paid taxes and utility";
        yield return new WaitForSeconds(2f);
        LabelText.text = "Bills for the previous two months.";
        yield return new WaitForSeconds(2.5f);
        LabelText.text = "Oh sir i can not pay them now...";
        yield return new WaitForSeconds(2.5f);
        LabelText.text = "I’ll have to turn off the electricity and";
        yield return new WaitForSeconds(2f);
        LabelText.text = "If you don’t pay soon you will go to jail.";
        yield return new WaitForSeconds(3f);
        LabelText.text = "Sir please...";
        yield return new WaitForSeconds(1.2f);
        LabelText.color = Color.red;
        LabelText.text = "...Call end...";
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
