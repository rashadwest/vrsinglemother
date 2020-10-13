using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterDangerArea : MonoBehaviour
{
    private Transform Target;

    public OVRScreenFade ScreenFade;

    private void Start()
    {
        Target = Camera.main.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != Target)
            return;

        ChangePosition();
    }

    void ChangePosition() {
        StartCoroutine(ScreenFade.Fade(0,1, value => {
            if (PlayerPrefs.GetString("Time") == "Day")
            {
                PlayerPrefs.SetString("Time", "Night");
            }
            else
            {
                PlayerPrefs.SetString("Time", "Day");
            }

            SceneManager.LoadScene("Environment");
        }));
    }
}
