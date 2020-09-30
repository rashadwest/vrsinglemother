using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JailBreathing : MonoBehaviour
{

    public AudioSource BreathingSoundEffect;
    public ParticleSystem FrostEffect;

    public Material Material;

    public Texture InFrost;

    private void Start()
    {
        if (PlayerPrefs.GetString("Breathing") == "on")
        {
            BreathingSoundEffect.gameObject.SetActive(true);
            FrostEffect.gameObject.SetActive(true);
            Material.mainTexture = InFrost;
        }
        else if ((PlayerPrefs.GetString("Breathing") == "off"))
        {
            BreathingSoundEffect.gameObject.SetActive(false);
            FrostEffect.gameObject.SetActive(false);
        }

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
