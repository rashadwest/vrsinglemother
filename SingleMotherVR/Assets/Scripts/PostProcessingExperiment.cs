using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;

public class PostProcessingExperiment : MonoBehaviour
{
    public PostProcessVolume Volume;

    private ColorGrading Color;
    private Vignette Vignate;

    private void Start()
    {
        Volume.profile.TryGetSettings(out Color);
        Volume.profile.TryGetSettings(out Vignate);
        Color.saturation.value = 0;
        Vignate.intensity.value = 0;
        Vignate.smoothness.value = 0;
    }

    private IEnumerator Anim()
    {
        yield return new WaitForSeconds(0);
        Color.saturation.value = Mathf.Lerp(Color.saturation.value, -100, 1f * Time.deltaTime);
        Vignate.intensity.value = Mathf.Lerp(Vignate.intensity.value, 0.3f, 1f * Time.deltaTime);
        Vignate.smoothness.value = Mathf.Lerp(Vignate.smoothness.value, 1, 1f * Time.deltaTime);
    }
}
