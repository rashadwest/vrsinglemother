using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JailMainEngine : MonoBehaviour
{
    [Header("General")]
    public OVRScreenFade ScreenFade;
    public PostProcessingEffects PostProcessingEffects;

    IEnumerator Start()
    {
        ScreenFade.enabled = true;
        PostProcessingEffects.SetValuesOne();
        yield return new WaitForSeconds(2f);
        //PostProcessingEffects.PlayToZero();
    }
}

