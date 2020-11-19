using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachMainEngine : MonoBehaviour
{
    [Header("General")]
    public OVRScreenFade ScreenFade;
    public PostProcessingEffects PostProcessingEffects;

    public AudioSource BeachAudio;

    IEnumerator Start()
    {
        ScreenFade.enabled = true;
        PostProcessingEffects.SetValuesOne();
        yield return new WaitForSeconds(2f);
        PostProcessingEffects.PlayToZero();

        BeachAudio.enabled = true;
        yield return new WaitForSeconds(5f);
        BeachAudio.enabled = false;
    }
}
