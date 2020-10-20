using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YardWorkController : MonoBehaviour
{
    [Header("General")]
    private Transform Target;
    public GameObject MissionParticle;
    public YardWorkEndTrigger MissonEndTrigger;
    public BoxCollider MissonStartTrigger;

    [Header("Label Part")]
    public GameObject LabelCanvas;
    public Text LabelText;

    private void Awake()
    {
        MissonEndTrigger.Callback += EndMission;
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
        LabelCanvas.GetComponent<Animator>().Play("CanvasGroupFadeIn");
        LabelCanvas.SetActive(true);
        MissonEndTrigger.gameObject.SetActive(true);

        StartCoroutine(PlaySubtitles());
    }

    IEnumerator PlaySubtitles()
    {
        LabelText.text = "";
        LabelText.color = Color.white;
        yield return new WaitForSeconds(1);
        LabelText.text = "Take the broom";
    }

    void EndMission() {
        MissionParticle.SetActive(true);
        MissonStartTrigger.enabled = true;
        LabelText.text = "Mission End";
        LabelText.color = Color.red;
        StartCoroutine(HideCanvas());
    }

    IEnumerator HideCanvas()
    {
        yield return new WaitForSeconds(0.6f);
        LabelCanvas.GetComponent<Animator>().Play("CanvasGroupFadeOut");
        yield return new WaitForSeconds(0.6f);
        LabelCanvas.SetActive(false);
    }
}
