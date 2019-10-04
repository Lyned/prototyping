using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToPickUp : MonoBehaviour {

    public bool inventory;  //If true this object can be stored in the inventory
    public bool openable;   // If true this object can be opened
    public bool locked;     //If true object is locked
    public GameObject itemNeeded;   //item needed in order to interact with this item

    public string itemType { get; internal set; }

    public void ItemInteraction()
    {
        if (gameObject.tag == "PickUp")
        {
            //Picked up and put in inventory
            gameObject.SetActive(false);           
        }        
    }    
}
