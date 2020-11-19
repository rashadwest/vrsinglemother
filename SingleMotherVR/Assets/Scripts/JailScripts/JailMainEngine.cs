using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JailMainEngine : MonoBehaviour
{
    [Header("General")]
    public OVRScreenFade ScreenFade;
    public PostProcessingEffects PostProcessingEffects;

    public AudioSource JailAudio;

    IEnumerator Start()
    {
        ScreenFade.enabled = true;
        PostProcessingEffects.SetValuesOne();
        yield return new WaitForSeconds(2f);
        PostProcessingEffects.PlayToZero();
        JailAudio.enabled = true;
        yield return new WaitForSeconds(5f);
        JailAudio.enabled = false;

    }
}

