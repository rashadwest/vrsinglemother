using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWardrobeController : MonoBehaviour
{
    public GameObject Hat;
    public GameObject Shoes;
    public GameObject Backpack;
    public GameObject Shirt;

    private int Count = 0;

    public RoomMissionController RoomMissionController;

    public void Clean() {
        Count = 0;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Hat")
        {
            Hat.SetActive(true);
            other.gameObject.SetActive(false);
            Count++;
        }
        else if (other.name == "Backpack")
        {
            Backpack.SetActive(true);
            other.gameObject.SetActive(false);
            Count++;
        }
        else if (other.name == "Shirt")
        {
            Shirt.SetActive(true);
            other.gameObject.SetActive(false);
            Count++;
        }
        else if (other.name == "Shoes")
        {
            Shoes.SetActive(true);
            other.gameObject.SetActive(false);
            Count++;
        }

        if (Count == 4)
        {
            RoomMissionController.GetSignal();
        }
    }
}
