using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSystemController : MonoBehaviour
{
    public GameObject[] Lights;
    [Space(10)]
    public GameObject[] DirectionalLights;

    [Space(20)]
    public Material DaySkybox;
    public Material NightSkybox;

    void Start()
    {
        Lights = GameObject.FindGameObjectsWithTag("Light");
        DirectionalLights = GameObject.FindGameObjectsWithTag("DirectionalLight");
    }

    public void SetTime() {
        if (PlayerPrefs.GetString("Time") == "Day")
        {
            for (int i = 0; i < Lights.Length; i++)
            {
                Lights[i].SetActive(false);
            }

            for (int i = 0; i < DirectionalLights.Length; i++)
            {
                DirectionalLights[i].SetActive(true);
            }

            RenderSettings.skybox = DaySkybox;
        }
        else if (PlayerPrefs.GetString("Time") == "Night")
        {
            for (int i = 0; i < Lights.Length; i++)
            {
                Lights[i].SetActive(true);
            }

            for (int i = 0; i < DirectionalLights.Length; i++)
            {
                DirectionalLights[i].SetActive(false);
            }

            RenderSettings.skybox = NightSkybox;
        }
    }
}
