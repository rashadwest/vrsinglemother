using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SofaSittingEvent : MonoBehaviour
{
    public CharacterController AvatarController;
    public Transform Avatar;
    public Transform AvatarChild;

    public GameObject Canvas;

    private Transform Target;

    public MainEngine Engine;

    public ShiningEffect SofaShiningEffect;

    public AudioSource TVAudio;

    public Button StandBtn;

    public YardWorkEndTrigger ExitTrigger;

    private void Awake()
    {
        StandBtn.onClick.AddListener(() => { StartCoroutine(StandUp()); });
        ExitTrigger.Callback += StandingUp;
    }

    private void Start()
    {
        Target = Camera.main.GetComponent<Transform>();
        ExitTrigger.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != Target)
            return;

        StartCoroutine(Sitting());
    }

    IEnumerator Sitting() {
        Canvas.SetActive(false);
        SofaShiningEffect.EndShining();
        StartCoroutine(Engine.SittingSofa());
        yield return new WaitForSeconds(1.5f);
        ExitTrigger.gameObject.SetActive(true);
        TVAudio.enabled = true;
    }

    void StandingUp() {
        StartCoroutine(StandUp());
    }

    IEnumerator StandUp()
    {
        ExitTrigger.gameObject.SetActive(false);
        AvatarController.enabled = false;
        TVAudio.enabled = false;
        Canvas.SetActive(false);
        SofaShiningEffect.StartShining();
        Avatar.localPosition = new Vector3(1.855703f, 0.05799973f, 5.598642f);
        AvatarChild.localPosition = new Vector3(0, 0.64f, 0);
        yield return new WaitForSeconds(0.2f);
        AvatarController.enabled = true;
    }
}
