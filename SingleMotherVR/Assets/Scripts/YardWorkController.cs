using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YardWorkController : MonoBehaviour
{
    [Header("General")]
    private bool IsStared = false;
    private Transform Target;
    public LawnMowerMissionController LawnMowerMission;
    public GameObject MissionParticle;
    public GameObject QuestionCanvas;
    public YardWorkEndTrigger MissonEndTrigger;
    public BoxCollider MissonStartTrigger;
    public AudioSource QuestionAudio;
    public CharacterController CharacterController;

    public Button YesBnt;
    public Button NoBnt;

    public Transform AvatarRightHand; 

    [Header("Label Part")]
    public GameObject LabelCanvas;
    public Text LabelText;

    [Header("Mission Elements")]
    public GameObject LawnMayer;
    public GameObject RakeOnScene;
    public GameObject RakePrefab;
    private GameObject Rake;
    public GameObject RakeCanvas;
    public Button RakeTakeBtn;

    private void Awake()
    {
        MissonEndTrigger.Callback += EndMissions;
        YesBnt.onClick.AddListener(ClickedYes);
        NoBnt.onClick.AddListener(ClickedNo);
        RakeTakeBtn.onClick.AddListener(TakingRake);
    }

    private void Start()
    {
        //Clear();
        Target = Camera.main.transform;
        MissonEndTrigger.gameObject.SetActive(false);
        IsStared = false;
    }

    public void Clear()
    {
        IsStared = false;
        LawnMayer.SetActive(true);
        MissionParticle.SetActive(true);
        //MissonEndTrigger.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != Target)
            return;

        if (!IsStared)
        {
            StartNewMission();
        }
    }

    public void StartNewMission()
    {
        IsStared = true;
        LawnMayer.SetActive(false);
        MissionParticle.SetActive(false);
        StartCoroutine(LawnMowerMission.Starting());
        MissonEndTrigger.gameObject.SetActive(true);
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
        Starting();
    }

    void ClickedNo()
    {
        QuestionAudio.enabled = false;
        EndMission();
        CharacterController.enabled = true;
        QuestionCanvas.SetActive(false);
        StartCoroutine(EndMission());
    }

    void Starting() {
        StartCoroutine(PlaySubtitles());
        RakeCanvas.SetActive(true);
    }

    void TakingRake()
    {
        RakeOnScene.SetActive(false);
        Rake = Instantiate(RakePrefab, AvatarRightHand);
        LabelText.text = "Clean the grass";
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
        LabelText.text = "Take the rake";
    }

    IEnumerator EndMission() {
        /* ----Old Mission------
        LabelText.text = "Mission End";
        LabelText.color = Color.red;
        StartCoroutine(HideCanvas());
        yield return new WaitForSeconds(2);
        MissionParticle.SetActive(true);
        MissonStartTrigger.enabled = true;
        */

        yield return new WaitForSeconds(0);
        MissionParticle.SetActive(true);
        MissonStartTrigger.enabled = true;
        LawnMowerMission.Ending();
        Clear();
    }

    IEnumerator HideCanvas()
    {
        yield return new WaitForSeconds(0.6f);
        LabelCanvas.GetComponent<Animator>().Play("CanvasGroupFadeOut");
        yield return new WaitForSeconds(0.6f);
        LabelCanvas.SetActive(false);
    }
}
