using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingCheck : MonoBehaviour
{
    public GameObject BreathingAudio;
    public GameObject BreathingFrost;

    private void Start()
    {
        if (PlayerPrefs.GetString("Breathing") == "on")
        {
            BreathingAudio.SetActive(true);
            BreathingFrost.SetActive(true);
        }
        else if ((PlayerPrefs.GetString("Breathing") == "off"))
        {
            BreathingAudio.SetActive(false);
            BreathingFrost.SetActive(false);
        }
    }
}
