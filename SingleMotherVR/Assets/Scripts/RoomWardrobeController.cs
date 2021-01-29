using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWardrobeController : MonoBehaviour
{
    public GameObject Hat;
    public GameObject Shoes;
    public GameObject Backpack;
    public GameObject Shirt;

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Hat")
        {
            Hat.SetActive(true);
            other.gameObject.SetActive(false);
        }
        else if (other.name == "Backpack")
        {
            Backpack.SetActive(true);
            other.gameObject.SetActive(false);
        }
        else if (other.name == "Shirt")
        {
            Shirt.SetActive(true);
            other.gameObject.SetActive(false);
        }
        else if (other.name == "Shoes")
        {
            Shoes.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }
}
