using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;

public class PostProcessingEffects : MonoBehaviour
{
    public PostProcessVolume Volume;

    private ColorGrading Color;
    private Vignette Vignate;

    private bool SetToOne = false;
    private bool SetToZero = false;

    private void Start()
    {
        Volume.profile.TryGetSettings(out Color);
        Volume.profile.TryGetSettings(out Vignate);
        Color.saturation.value = 0;

        Vignate.intensity.value = 0;
        Vignate.smoothness.value = 0;
    }

    public void SetValuesZero()
    {
        SetToZero = false;
        SetToOne = false;

        Color.saturation.value = 0;

        Vignate.intensity.value = 0;
        Vignate.smoothness.value = 0;
    }

    public void SetValuesOne()
    {
        SetToZero = false;
        SetToOne = false;

        Color.saturation.value = -100;

        Vignate.intensity.value = 0.4f;
        Vignate.smoothness.value = 1;
    }

    public void PlayToOne() {
        SetToOne = true;
        SetToZero = false;
    }

    public void PlayToZero()
    {
        SetToZero = true;
        SetToOne = false;
    }

    private void Update()
    {
        if (SetToOne)
        {
            Color.saturation.value = Mathf.Lerp(Color.saturation.value, -100, 1f * Time.deltaTime);
            Vignate.intensity.value = Mathf.Lerp(Vignate.intensity.value, 0.4f, 1f * Time.deltaTime);
            Vignate.smoothness.value = Mathf.Lerp(Vignate.smoothness.value, 1, 1f * Time.deltaTime);
        }

        if (SetToZero)
        {
            Color.saturation.value = Mathf.Lerp(Color.saturation.value, 0, 1f * Time.deltaTime);
            Vignate.intensity.value = Mathf.Lerp(Vignate.intensity.value, 0f, 1f * Time.deltaTime);
            Vignate.smoothness.value = Mathf.Lerp(Vignate.smoothness.value, 0, 1f * Time.deltaTime);
        }
    }
}
