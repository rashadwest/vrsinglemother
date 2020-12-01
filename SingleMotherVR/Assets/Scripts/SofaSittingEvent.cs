using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SofaSittingEvent : MonoBehaviour
{
    public CharacterController AvatarController;
    public Transform Avatar;

    public GameObject Canvas;

    private Transform Target;

    public MainEngine Engine;

    public ShiningEffect SofaShiningEffect;

    public AudioSource TVAudio;

    public Button StandBtn;

    private void Awake()
    {
        StandBtn.onClick.AddListener(() => { StartCoroutine(StandUp()); });
    }

    private void Start()
    {
        Target = Camera.main.GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != Target)
            return;

        StartCoroutine(Sitting());
    }

    IEnumerator Sitting() {
        Canvas.SetActive(true);
        SofaShiningEffect.EndShining();
        Engine.SittingSofa();
        yield return new WaitForSeconds(1.5f);
        TVAudio.enabled = true;
    }

    IEnumerator StandUp() {
        AvatarController.enabled = false;
        TVAudio.enabled = false;
        Canvas.SetActive(false);
        SofaShiningEffect.StartShining();
        Avatar.localPosition = new Vector3(1.855703f, 0.05799961f, 5.598642f);
        yield return new WaitForSeconds(0.2f);
        AvatarController.enabled = true;
    }
}
