using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YardWorkController : MonoBehaviour
{
    [Header("General")]
    private Transform Target;
    public GameObject MissionParticle;
    public GameObject QuestionCanvas;
    public YardWorkEndTrigger MissonEndTrigger;
    public BoxCollider MissonStartTrigger;
    public AudioSource QuestionAudio;
    public CharacterController CharacterController;

    public Button YesBnt;
    public Button NoBnt;

    [Header("Label Part")]
    public GameObject LabelCanvas;
    public Text LabelText;

    private void Awake()
    {
        MissonEndTrigger.Callback += EndMissions;
        YesBnt.onClick.AddListener(ClickedYes);
        NoBnt.onClick.AddListener(ClickedNo);
    }

    private void Start()
    {
        Target = Camera.main.transform;
        LabelCanvas.SetActive(false);
        MissonEndTrigger.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != Target)
            return;

        StartMission();
    }

    void StartMission() {
        MissonStartTrigger.enabled = false;
        MissionParticle.SetActive(false);
        MissonEndTrigger.gameObject.SetActive(true);

        StartCoroutine(ShowQuestion());
    }

    IEnumerator ShowQuestion()
    {
        CharacterController.enabled = false;
        QuestionAudio.enabled = true;
        yield return new WaitForSeconds(2);
        QuestionCanvas.SetActive(true);
    }

    void ClickedYes() {
        CharacterController.enabled = false;
        QuestionCanvas.SetActive(false);
        StartCoroutine(PlaySubtitles());
    }

    void ClickedNo()
    {
        QuestionAudio.enabled = false;
        EndMission();
        CharacterController.enabled = true;
        QuestionCanvas.SetActive(false);
        StartCoroutine(EndMission());
    }

    void EndMissions() {
        StartCoroutine(EndMission());
    }

    IEnumerator PlaySubtitles()
    {
        CharacterController.enabled = true;
        LabelCanvas.GetComponent<Animator>().Play("CanvasGroupFadeIn");
        LabelCanvas.SetActive(true);

        LabelText.text = "";
        LabelText.color = Color.white;
        yield return new WaitForSeconds(1);
        LabelText.text = "Take the broom";
    }

    IEnumerator EndMission() {
        LabelText.text = "Mission End";
        LabelText.color = Color.red;
        StartCoroutine(HideCanvas());
        yield return new WaitForSeconds(2);
        MissionParticle.SetActive(true);
        MissonStartTrigger.enabled = true;
    }

    IEnumerator HideCanvas()
    {
        yield return new WaitForSeconds(0.6f);
        LabelCanvas.GetComponent<Animator>().Play("CanvasGroupFadeOut");
        yield return new WaitForSeconds(0.6f);
        LabelCanvas.SetActive(false);
    }
}
