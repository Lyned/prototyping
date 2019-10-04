using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public static Inventory instance;

    public static GameObject[] inventory = new GameObject[4];
    public Button[] InventoryButtons = new Button[4];

    private void Start()
    {
        instance = this;
    }

    public void AddItem(GameObject item)
    {
        bool itemAdded = false;

        //Find the first open slot in the inventory
        for(int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i] == null)
            {
                inventory[i] = item;
                //Update UI
                InventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                Debug.Log(item.name + " was added");
                itemAdded = true;
                //Do something with the object
                item.GetComponent<ItemToPickUp>().ItemInteraction();
                break;
            }
        }

        //Inventory full
        if (!itemAdded)
        {
            Debug.Log("Inventory Full - Item Not Added");
        }
    }

    public bool FindItem(GameObject item)
    {
        for(int i= 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                //We found the item
                return true;
            }
        }
        //item not found
        return false;
    }

    public GameObject FindItemByType(string itemType)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                if(inventory [i].GetComponent<ItemToPickUp>().itemType == itemType)
                {
                    //We found an item of the type we were looking for
                    return inventory[i];
                }
            }
        }
        //item of type not found
        return null;
    }

    public void RemoveItem(GameObject item)
    {
        for(int i= 0; i < inventory.Length; i++)
        {
            if(inventory[i] == item)
            {
                //Update UI - default sprite buttons   InventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                //we found the item - Remove it
                inventory[i] = null;
                InventoryButtons[i].image.overrideSprite = null;

                Debug.Log(item.name + " was removed from inventory");
                break;
            }
        }
    }  

}
