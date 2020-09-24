using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitToMenuController : MonoBehaviour
{
    public MainEngine Engine;

    public Button ExitBtn;

    private void Awake()
    {
        ExitBtn.onClick.AddListener(Exit);
    }

    void Exit() {
        Engine.GoToMenu();
    }
}
