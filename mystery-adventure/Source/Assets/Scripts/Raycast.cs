using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    RaycastHit2D hit;
    public GameObject currentInterObj = null;
    public ItemToPickUp currentItemToPickUp = null;
    public Inventory inventory;


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        hit = Physics2D.GetRayIntersection(ray);
        if (hit.collider != null)
        {
            print(hit.collider.gameObject.name);
            Debug.DrawLine(ray.origin, hit.point);

            currentInterObj = hit.collider.gameObject;

            // Check if InterObj is an ItemToPickUp
            if (currentInterObj.GetComponent<ItemToPickUp>() != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    currentItemToPickUp = currentInterObj.GetComponent<ItemToPickUp>();
                    InteractionWithItems();
                }
            }

            if (currentInterObj.tag == "Removeable")
            {
                print("should remove");

                if (Input.GetMouseButtonDown(0))
                {
                    print("remove");
                    currentInterObj.gameObject.SetActive(false);
                }
            }
        }
    }

    void InteractionWithItems()
    {
        //check to see if this object is to be stored in inventory
        if (currentItemToPickUp.inventory)
        {
            inventory.AddItem(currentInterObj);
            AudioManager.instance.PlaySound("PickingUpItem");
        }
        //Check to see if this object can be opend
        if (currentItemToPickUp.openable)
        {
            //Check to see if the object is locked
            if (currentItemToPickUp.locked)
            {
                //Check to see if we have the object needed to unlock
                //Search our inventory for the item needed - and if found unlock object
                if (inventory.FindItem(currentItemToPickUp.itemNeeded))
                {
                    //We found the item needed
                    currentItemToPickUp.locked = false;
                    Debug.Log(currentInterObj.name + " was unlocked");
                    currentItemToPickUp.gameObject.SetActive(false);

                    print("Item = " + currentItemToPickUp.itemNeeded);
                    Inventory.instance.RemoveItem(currentItemToPickUp.itemNeeded);
                }
                else
                {
                    Debug.Log(currentInterObj.name + " was not unlocked");
                }
            }
            else
            {
                //object is not locked - open the object
                Debug.Log(currentInterObj.name + " is unlocked");
            }
        }
    }
}

