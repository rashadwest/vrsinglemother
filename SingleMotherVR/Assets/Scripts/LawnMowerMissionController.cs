using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnMowerMissionController : MonoBehaviour
{
    public GameObject LawnMawerPrefab;
    public Transform LawnMawerParent;
    public Transform Avatar;
    public CharacterController AvatarController;
    public Vector3 StartingPosition;

    private Transform Cam;
    private GameObject LawnMawer;

    private void Start()
    {
        Cam = Camera.main.transform;

        StartMission();
    }

    void StartMission() {
        AvatarController.enabled = false;
        Avatar.localPosition = StartingPosition;
        AvatarController.enabled = true;

        LawnMawer = Instantiate(LawnMawerPrefab, LawnMawerParent);
    }
}
