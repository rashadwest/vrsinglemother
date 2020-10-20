using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CurvedUI;

public class RuntimePlatformCheck : MonoBehaviour
{
    private CurvedUISettings CurvedUI;

    void Start()
    {
        CurvedUI = GetComponent<CurvedUISettings>();

        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            CurvedUI.ControlMethod = CurvedUIInputModule.CUIControlMethod.MOUSE;
        }
        else
        {
            CurvedUI.ControlMethod = CurvedUIInputModule.CUIControlMethod.OCULUSVR;
        }
    }
}
