using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWardrobeController : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Hat")
        {
            //Hat
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
