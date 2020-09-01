using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathing : MonoBehaviour
{
    public ParticleSystem FrostEffect;

    public AudioSource BreathingSoundEffect;

    private void Start()
    {
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
}
