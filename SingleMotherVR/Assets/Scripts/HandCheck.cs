using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CurvedUI;

public class HandCheck : MonoBehaviour
{
    public CurvedUIInputModule EventSystem;

    public CurvedUIHandSwitcher HandSwitcher;

    private void Start()
    {
        if (PlayerPrefs.GetString("Hand") == "left")
        {
            EventSystem.UsedHand = CurvedUIInputModule.Hand.Left;
            HandSwitcher.SwitchHandTo(CurvedUIInputModule.Hand.Left);
        }
        else if ((PlayerPrefs.GetString("Hand") == "right"))
        {
            EventSystem.UsedHand = CurvedUIInputModule.Hand.Right;
            HandSwitcher.SwitchHandTo(CurvedUIInputModule.Hand.Right);
        }
    }
}
