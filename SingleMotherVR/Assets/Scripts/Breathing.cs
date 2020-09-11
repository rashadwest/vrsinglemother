using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathing : MonoBehaviour
{
    public ParticleSystem FrostEffect;

    public AudioSource BreathingSoundEffect;

    public Material Material;

    public Texture OutFrost;
    public Texture InFrost;

    private Transform Target;

    private void Start()
    {
        Target = Camera.main.GetComponent<Transform>();
        BreathingSoundEffect.Pause();
        StartCoroutine(StartBreathing());
    }

    IEnumerator StartBreathing()
    {
        BreathingSoundEffect.Play();
        yield return new WaitForSeconds(1);
        FrostEffect.Play();
        yield return new WaitForSeconds(5);
        StartCoroutine(StartBreathing());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != Target)
            return;

        Material.mainTexture = InFrost;
        BreathingSoundEffect.volume = 0.2f;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform != Target)
            return;

        Material.mainTexture = OutFrost;
        BreathingSoundEffect.volume = 0.5f;
    }
}
