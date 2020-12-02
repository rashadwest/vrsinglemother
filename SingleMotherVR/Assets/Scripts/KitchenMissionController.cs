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
    public GameObject ExitCanvas;
    public Button ExitButton;

    private void Awake()
    {
        StartCallBtn.onClick.AddListener(()=> { StartCoroutine(StartCall()); });
        EndCallBtn.onClick.AddListener(()=> { StartCoroutine(EndCall()); });
        ExitButton.onClick.AddListener(()=> { StartCoroutine(QuitMission()); });
    }

    private void Start()
    {
        Target = Camera.main.transform;
        Canvas.SetActive(false);
        ExitCanvas.SetActive(false);
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
        ExitCanvas.SetActive(true);

        yield return new WaitForSeconds(0.2f);
        TelephoneAnim.Play("TelephoneRinging");
    }

    IEnumerator StartCall()
    {
        ExitCanvas.SetActive(false);
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
        LabelText.text = "Hey is this Mrs. Smith?";
        yield return new WaitForSeconds(2f);
        LabelText.text = "Yes this is her.";
        yield return new WaitForSeconds(2f);
        LabelText.text = "You owe us $500 dollars for rent.";
        yield return new WaitForSeconds(2.5f);
        LabelText.text = "Could you have that to us by the end of the day.";
        yield return new WaitForSeconds(3.5f);
        LabelText.text = "I do not have money to pay but if you could";
        yield return new WaitForSeconds(2.5f);
        LabelText.text = "Give me until the end of the week I will find it.";
        yield return new WaitForSeconds(3f);
        LabelText.text = "You have until the end of the day!";
        yield return new WaitForSeconds(2.2f);
        LabelText.color = Color.red;
        LabelText.text = "...Call end...";
    }

    IEnumerator EndCall()
    {
        ExitCanvas.SetActive(true);
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

    IEnumerator QuitMission()
    {
        Particle.SetActive(true);
        ExitCanvas.SetActive(false);
        AvatarController.enabled = false;
        Avatar.localPosition = new Vector3(2.255588f, 0.05799985f, 4.734963f);
        TelephoneAnim.enabled = true;
        RingingAudio.enabled = false;
        Phone.SetActive(true);
        Canvas.GetComponent<Animator>().Play("CanvasGroupFadeOut");
        TelephoneAnim.Play("New State");
        yield return new WaitForSeconds(0.6f);
        Canvas.SetActive(false);
        AvatarController.enabled = true;
    }
}
