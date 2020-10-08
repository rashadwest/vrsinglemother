using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeachChairSittingEvent : MonoBehaviour
{
    private Transform Target;

    public Transform Avatar;
    public Transform LookAtObject;
    public CharacterController AvatarController;

    public GameObject ButtonCanvas;

    public Vector3 SitPosition;
    public Vector3 StandPosition;

    public Button StandBtn;

    private void Awake()
    {
        StandBtn.onClick.AddListener(Standing);
    }

    private void Start()
    {
        ButtonCanvas.SetActive(false);
        Target = Camera.main.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != Target)
            return;

        Sitting();
    }

    void Sitting() {
        ButtonCanvas.SetActive(true);
        AvatarController.enabled = false;
        Avatar.localPosition = SitPosition;
        Avatar.LookAt(LookAtObject);
    }


    void Standing()
    {
        ButtonCanvas.SetActive(false);
        Avatar.localPosition = StandPosition;
        AvatarController.enabled = true;
    }
}
