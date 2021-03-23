using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankAccaunt : MonoBehaviour
{
    public Button CloseBtn;
    public Text AmmountText;

    public GameObject BankAccauntCanvas;

    private void Awake()
    {
        CloseBtn.onClick.AddListener(Close);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        AmmountText.text = PlayerPrefs.GetString("BankAccaunt");
    }

    void Close() {
        gameObject.SetActive(false);

        BankAccauntCanvas.SetActive(true);
    }
}
