using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaSittingEvent : MonoBehaviour
{
    private Transform Target;

    public MainEngine Engine;

    public ShiningEffect SofaShiningEffect;

    public AudioSource TVAudio;

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
        SofaShiningEffect.EndShining();
        Engine.SittingSofa();
        yield return new WaitForSeconds(1.5f);
        TVAudio.enabled = true;
        yield return new WaitForSeconds(4);
        TVAudio.enabled = false;
    }
}
