using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{


    public void PlayerInteract()
    {
        //Inventory.main = null; // This would berak the inventory

        Inventory.main.hasKey = true;

        // remember that the playe has picked up the object


        Destroy(gameObject);
    }
}
