using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YardWorkController : MonoBehaviour
{
    [Header("General")]
    private Transform Target;
    public GameObject MissionParticle;

    [Header("Label Part")]
    public GameObject LabelCanvas;
    public Text LabelText;

    private void Start()
    {
        Target = Camera.main.transform;
        LabelCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != Target)
            return;

        StartMission();
    }

    void StartMission() {
        MissionParticle.SetActive(false);
        LabelCanvas.SetActive(true);
    }
}
