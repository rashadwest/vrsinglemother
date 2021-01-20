using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWardrobeController : MonoBehaviour
{
    public GameObject Hat;

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Hat")
        {
            Hat.SetActive(true);
            other.gameObject.SetActive(false);
        }
        else if (other.name == "Backpack")
        {
            //Backpack
        }
        else if (other.name == "Shirt")
        {
            //Shirt
        }
        else if (other.name == "Shoes")
        {
            //Shoes
        }
    }
}
